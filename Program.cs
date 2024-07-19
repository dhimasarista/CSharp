using System;
using System.Threading.Tasks;

class Program
{

    public static async Task Main(string[] args)
    {
        // Concurrent execution of tasks using 'await'
        var concurrentTasks = new List<Task>();
        for (int i = 0; i < 4; i++)
        {
            concurrentTasks.Add(Task.Run(async () =>
            {
                Console.WriteLine($"Concurrent Task {i} started");
                // Simulate some work
                await Task.Delay(1000);
                Console.WriteLine($"Concurrent Task {i} completed");
            }));
        }

        // Wait for all concurrent tasks to complete
        await Task.WhenAll(concurrentTasks);

        // Parallel execution of tasks using TPL
        var parallelTasks = new ParallelOptions { MaxDegreeOfParallelism = 4 };
        Parallel.ForEach(Enumerable.Range(0, 4), parallelTasks, (i) =>
        {
            Console.WriteLine($"Parallel Task {i} started");
            // Simulate some work
            Thread.Sleep(1000);
            Console.WriteLine($"Parallel Task {i} completed");
        });
    }
}