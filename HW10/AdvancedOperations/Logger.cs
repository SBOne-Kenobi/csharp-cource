namespace AdvancedOperations;

public static class Logger
{
    private const string FileName = "AdvancedOperations.log";

    public static void Log(string message)
    {
        var file = File.AppendText(FileName);
        file.Write(message);
        file.Close();
    }
}