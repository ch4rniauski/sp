const int numWorkers = 5;
const int semaphoreCapacity = 3;
const int signalIntervalMs = 10_000;

var autoResetEvent = new AutoResetEvent(false);
var semaphore = new SemaphoreSlim(semaphoreCapacity, semaphoreCapacity);
var obj = new object();

for (var i = 0; i < numWorkers; i++)
{
    var id = i + 1;
    
    _ = Task.Run(() => Worker(id));
}

while (true)
{
    await Task.Delay(signalIntervalMs);
    
    lock (obj)
    {
        Console.WriteLine("\nТревога! Рабочие идут проверять участок\n");
    }
    
    for (var i = 0; i < numWorkers; i++)
    {
        autoResetEvent.Set();
    }
}

void Worker(int id)
{
    const int checkDurationMs = 2_000;
    
    while (true)
    {
        Console.WriteLine($"Рабочий {id} ждёт тревоги");
        
        autoResetEvent.WaitOne();
        
        if (semaphore.Wait(0))
        {
            lock (obj)
            {
                Console.WriteLine($"Рабочий {id} проверяет участок");
            }
            
            Thread.Sleep(checkDurationMs);
            
            lock (obj)
            {
                Console.WriteLine($"Рабочий {id} закончил проверку");
            }
            
            semaphore.Release();
        }
    }
}
