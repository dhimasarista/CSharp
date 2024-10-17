using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        const int iterations = 10_000_000;

        // Task Parallel
        var sw = Stopwatch.StartNew();
        Parallel.For(0, iterations, i =>
        {
            var result = Math.Sqrt(i);
        });
        sw.Stop();
        Console.WriteLine($"Task Parallel Execution Time: {sw.ElapsedMilliseconds} ms");

        // Async
        sw.Restart();
        var tasks = new Task[iterations];
        for (int i = 0; i < iterations; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                var result = Math.Sqrt(i);
            });
        }
        await Task.WhenAll(tasks);
        sw.Stop();
        Console.WriteLine($"Async Execution Time: {sw.ElapsedMilliseconds} ms");
    }
}
