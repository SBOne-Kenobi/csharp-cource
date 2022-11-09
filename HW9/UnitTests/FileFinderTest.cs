using FileFinder;

namespace UnitTests;

public class FileFinderTest
{
    [Fact]
    public void Test()
    {
        var rootPath = Directory.GetCurrentDirectory();

        var current = new DirectoryInfo(rootPath + Path.DirectorySeparatorChar + "test_test___test");
        current.Create();
        
        var fileInfo = new FileInfo(current.FullName + Path.DirectorySeparatorChar + "new_file_lol_228.html");
        fileInfo.Create();

        var path = FileFinderUtil.FindFile("new_file_lol_228", rootPath);
        
        Assert.Equal(fileInfo.FullName, path);
    }
}