string path = @"c:\Users\Admin\Downloads\30da91a108";

DirectoryInfo di = new DirectoryInfo(path);

try
{
    if (di.Exists)
    {
        var allFilesPaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        foreach (var filePath in allFilesPaths)
        {
            if (File.Exists(filePath))
            {
                var file = new FileInfo(filePath);

                if ((DateTime.Now - file.LastWriteTime).TotalMinutes > 30)
                    file.Delete();
            }
            else
                Console.WriteLine($"Некорректный путь файла '{filePath}'!");
        }

        var allDirsPaths = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
        foreach (var dirPath in allDirsPaths)
        {
            if (Directory.Exists(dirPath))
            {
                var dir = new DirectoryInfo(dirPath);

                if ((DateTime.Now - dir.LastWriteTime).TotalMinutes > 30)
                    dir.Delete();
            }
            else
                Console.WriteLine($"Некорректный путь внутреннего каталога '{dirPath}'!");
        }
    }
    else
        Console.WriteLine($"Некорректный путь каталога '{path}'!");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка! {ex.Message}");
}
