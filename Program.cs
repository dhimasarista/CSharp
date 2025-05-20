using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static int Fibonacci(int n)
    {
        return n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static async Task Main(string[] args)
    {
        var proc = Process.GetCurrentProcess();
        int cores = Environment.ProcessorCount;

        // --- Sebelum eksekusi ---
        GC.Collect();
        long memBefore = GC.GetTotalMemory(true);
        TimeSpan cpuBefore = proc.TotalProcessorTime;
        Console.WriteLine(">> BEFORE:");
        Console.WriteLine($"Used Memory: {memBefore:N0} bytes ({memBefore/1024/1024:N0} MB)");
        Console.WriteLine($"Process CPU Time: {cpuBefore.TotalMilliseconds:N0} ms");

        var sw = Stopwatch.StartNew();

        // --- Jalankan 10 task Fibonacci(40) paralel ---
        var options = new ParallelOptions { MaxDegreeOfParallelism = cores };
        await Task.Run(() =>
            Parallel.For(0, 10, options, i =>
            {
                int result = Fibonacci(40);
                Console.WriteLine($"Fib(40) = {result}");
            })
        );

        sw.Stop();
        proc.Refresh();

        // --- Sesudah eksekusi ---
        GC.Collect();
        long memAfter = GC.GetTotalMemory(true);
        TimeSpan cpuAfter = proc.TotalProcessorTime;
        Console.WriteLine("\n>> AFTER:");
        Console.WriteLine($"Used Memory: {memAfter:N0} bytes ({memAfter/1024/1024:N0} MB)");
        long deltaMem = memAfter - memBefore;
        Console.WriteLine($"Delta Memory: {deltaMem:N0} bytes ({deltaMem/1024/1024:N0} MB)");
        Console.WriteLine($"Process CPU Time: {cpuAfter.TotalMilliseconds:N0} ms");
        double deltaCpuMs = (cpuAfter - cpuBefore).TotalMilliseconds;
        Console.WriteLine($"Delta CPU Time: {deltaCpuMs:N0} ms");
        Console.WriteLine($"Wall-clock Time: {sw.ElapsedMilliseconds:N0} ms");

        double cpuUsagePerCore = deltaCpuMs / (sw.Elapsed.TotalMilliseconds * cores) * 100.0;
        Console.WriteLine($"Approx. CPU Usage/Core: {cpuUsagePerCore:F2}%");
    }
}
