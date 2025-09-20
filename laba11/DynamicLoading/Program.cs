using System.Reflection;

const string path = "../../../../Library/bin/Debug/net9.0/Library.dll";
const string typeName = "Library.StringManager";
const string methodName = "CountVowels";

Console.Write("Введите слово: ");

var word = Console.ReadLine();

try
{
    var asm = Assembly.LoadFrom(path);
    var type = asm.GetType(typeName);
    var method = type?.GetMethod(methodName);

    var result = method?.Invoke(null, [word]);
    Console.WriteLine($"Гласных: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}