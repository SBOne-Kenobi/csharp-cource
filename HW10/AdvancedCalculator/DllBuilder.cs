using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AdvancedCalculator;

public class DllBuilder
{
    private string _code = "";
    private AssemblyLoadContext? _loadContext;

    private AssemblyLoadContext RefreshContext()
    {
        _loadContext?.Unload();
        var newContext = new AssemblyLoadContext("calculator", true);
        _loadContext = newContext;
        return newContext;
    }
    
    public void SetCode(string code)
    {
        _code = code;
    }

    public Assembly CreateDll()
    {
        var codeTree = CSharpSyntaxTree.ParseText(_code);

        var refPaths = new[]
        {
            typeof(object).GetTypeInfo().Assembly.Location,
            typeof(Assembly).GetTypeInfo().Assembly.Location,
        };
        var references = refPaths.Select(r => MetadataReference.CreateFromFile(r)).ToArray();

        var compilation = CSharpCompilation.Create(
            "Temp.dll",
            syntaxTrees: new[] { codeTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);

        if (!result.Success)
        {
            var errorBuilder = new StringBuilder();

            errorBuilder.AppendLine("Compilation failed!");
            
            var failures = result.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError ||
                diagnostic.Severity == DiagnosticSeverity.Error);

            foreach (var diagnostic in failures)
            {
                errorBuilder.AppendLine($"\t{diagnostic.Id}: {diagnostic.GetMessage()}");
            }

            throw new Exception(errorBuilder.ToString());
        }

        ms.Seek(0, SeekOrigin.Begin);

        return RefreshContext().LoadFromStream(ms);
    }
}