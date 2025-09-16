const int numUsers = 3;
const int coffeeBrewTimeMs = 5_000;
const int programDurationMs = 30_000;

var coffeeReadyEvent = new AutoResetEvent(false);
var cupSemaphore = new SemaphoreSlim(1, 1);
var consoleLock = new object();
var stop = false;
var tasks = new Task[numUsers];

for (var i = 0; i < numUsers; i++)
{
    var id = i + 1;
    
    tasks[i] = Task.Run( () => UserThread(id) );
}

var timerEvent = new AutoResetEvent(false);

var regHandle = ThreadPool.RegisterWaitForSingleObject(
    timerEvent,
    (_, _) =>
    {
        if (stop)
        {
            return;
        }

        lock (consoleLock)
        {
            Console.WriteLine("\nКофемашина: кофе готов\n");
        }

        for (var i = 0; i < numUsers; i++)
        {
            coffeeReadyEvent.Set();
        }
    },
    null,
    coffeeBrewTimeMs,
    false);

await using var periodicTimer = new Timer(
    _ => timerEvent.Set(),
    null,
    0,
    coffeeBrewTimeMs);

await Task.Delay(programDurationMs);

regHandle.Unregister(null);

stop = true;

for (var i = 0; i < numUsers; i++)
{
    coffeeReadyEvent.Set();
}

Task.WaitAll(tasks);

void UserThread(int id)
{
    const int drinkTimeMs = 2_000;
    
    while (!stop)
    {
        lock (consoleLock)
        {
            Console.WriteLine($"Пользователь {id} ждёт кофе");
        }

        coffeeReadyEvent.WaitOne();

        if (stop)
        {
            break;
        }

        if (cupSemaphore.Wait(0))
        {
            lock (consoleLock)
            {
                Console.WriteLine($"Пользователь {id} пьёт кофе");
            }

            Thread.Sleep(drinkTimeMs);

            lock (consoleLock)
            {
                Console.WriteLine($"Пользователь {id} закончил пить кофе");
            }

            cupSemaphore.Release();
        }
    }
}
