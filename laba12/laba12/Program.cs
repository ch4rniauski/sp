using System.Text.RegularExpressions;

if (!File.Exists("input.txt"))
{
    Console.WriteLine("Файл input.txt не найден.");
    return;
}

try
{
    var lines = File.ReadLines("input.txt");
    var digitLines = lines.Where(line => Regex.IsMatch(line, @"\d")).ToList();

    File.WriteAllLines("output.txt", digitLines);
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
