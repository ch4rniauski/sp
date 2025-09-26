using System.Runtime.InteropServices;

FileStream? fs = null;

try
{
    fs = new FileStream("shared.txt",
        FileMode.OpenOrCreate,
        FileAccess.ReadWrite,
        FileShare.None);

    using var writer = new StreamWriter(fs, leaveOpen: true);
    
    writer.WriteLine("Test line to flush");
    writer.Flush();

    var ok = FlushFileBuffers(fs.SafeFileHandle.DangerousGetHandle());
    Console.WriteLine(ok
        ? "FlushFileBuffers выполнен успешно"
        : "FlushFileBuffers завершился с ошибкой");
}
catch (IOException ex)
{
    Console.WriteLine("Ошибка доступа к файлу: " + ex.Message);
}
finally
{
    fs?.Close();
}

[DllImport("kernel32.dll", SetLastError = true)]
static extern bool FlushFileBuffers(IntPtr hFile);
