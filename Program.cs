string path = @"c:\Users\Admin\Downloads\30da91a108";

DirectoryInfo di = new DirectoryInfo(path);

try
{
    if (di.Exists)
    {
        foreach (FileInfo file in di.GetFiles().Where(x => (DateTime.Now - x.LastWriteTime).TotalMinutes > 30))
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in di.GetDirectories().Where(x => (DateTime.Now - x.LastWriteTime).TotalMinutes > 30))
        {
            dir.Delete(true);
        }
    }
    else
        Console.WriteLine("Некорректный путь!");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка! {ex.Message}");
}
