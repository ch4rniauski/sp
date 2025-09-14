int threadsCount;
int passwordLength;
int complexity;

while (true)
{
    Console.Write("Введите количество потоков: ");

    var number = Console.ReadLine();

    if (!int.TryParse(number, out threadsCount))
    {
        Console.Clear();
        Console.WriteLine("Введите подходящее число");
        
        continue;
    }
    
    Console.Clear();
    break;
}

while (true)
{
    Console.Write("Введите желаемую длину пароля: ");

    var number = Console.ReadLine();

    if (!int.TryParse(number, out passwordLength))
    {
        Console.Clear();
        Console.WriteLine("Введите подходящее число");
        
        continue;
    }
    
    Console.Clear();
    break;
}

while (true)
{
    Console.WriteLine("Выберите сложность пароля");
    Console.WriteLine("1 - Легкая");
    Console.WriteLine("2 - Средняя");
    Console.WriteLine("3 - Тяжелая");

    var number = Console.ReadLine();

    if (!int.TryParse(number, out complexity))
    {
        Console.Clear();
        Console.WriteLine("Введите подходящее число");
        
        continue;
    }

    switch (complexity)
    {
        case 1 or 2 or 3:
            break;
        default:
            Console.Clear();
            Console.WriteLine("Введите подходящее число");
            break;
    }
    
    Console.Clear();
    break;
}

var tasks = new Task[threadsCount];

for (var i = 0; i < threadsCount; i++)
{
    var threadNum = i + 1;
    
    tasks[i] = Task.Run(() =>
    {
        var password = GeneratePassword(passwordLength, complexity);
        
        Console.WriteLine($"Поток №{threadNum}\tID={Environment.CurrentManagedThreadId}\tПароль: {password}");
    });
}

Task.WaitAll(tasks);

static string GeneratePassword(int length, int complexity)
{
    const string lower = "abcdefghijklmnopqrstuvwxyz";
    const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string digits = "0123456789";
    const string symbols = "!@#$%^&*()_+-=[]{};:,.<>?";

    var chars = complexity switch
    {
        1 => lower + digits,
        2 => lower + upper + digits,
        3 => lower + upper + digits + symbols,
        _ => lower + upper + digits
    };

    var rnd = new Random();
    
    return new string(
        Enumerable.Range(0, length)
        .Select(_ => chars[ rnd.Next(chars.Length) ])
        .ToArray());
}
