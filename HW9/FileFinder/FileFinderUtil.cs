namespace FileFinder;

public static class FileFinderUtil
{
    private record Filename(string Name, string Ext)
    {
        public bool Matches(string filename)
        {
            if (Ext == "")
            {
                return Path.GetFileNameWithoutExtension(filename) == Name;
            }

            return filename == $"{Name}.{Ext}";
        }
    }
    
    public static string? FindFile(string filename, string? root = null)
    {
        var rootPath = root ?? Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
        var dir = new DirectoryInfo(rootPath);

        var filenameObj = new Filename(Path.GetFileNameWithoutExtension(filename), Path.GetExtension(filename));

        return FindFileImpl(filenameObj, dir);
    }

    private static string? FindFileImpl(Filename filename, DirectoryInfo dir)
    {
        foreach (var fileInfo in dir.GetFiles())
        {
            if (filename.Matches(fileInfo.Name))
            {
                return fileInfo.FullName;
            }
        }

        foreach (var directoryInfo in dir.GetDirectories())
        {
            var res = FindFileImpl(filename, directoryInfo);
            if (res != null)
            {
                return res;
            }
        }
        
        return null;
    }
}