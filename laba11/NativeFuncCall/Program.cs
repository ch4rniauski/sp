using System.Runtime.InteropServices;

Console.Write("Введите слово: ");

var word = Console.ReadLine();

var result = CountVowels(word!);
Console.WriteLine($"Гласных: {result}");

[DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl)]
static extern int CountVowels(string str);
