using Library;

Console.Write("Введите слово: ");

var word = Console.ReadLine();

var count = StringManager.CountVowels(word!);

Console.WriteLine($"Результат: {count}");
