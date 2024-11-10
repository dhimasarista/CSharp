using System;
using System.Diagnostics;
using System.Runtime;

class Program
{
    static void Main()
    {
        // Set GC Latency Mode ke Batch
        GCSettings.LatencyMode = GCLatencyMode.Batch;

        Console.WriteLine("GC Latency Mode: Batch");

        // Mengukur waktu eksekusi
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Simulasi alokasi objek
        for (int i = 0; i < 1000000; i++)
        {
            var obj = new object(); // Membuat objek baru
        }

        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("Done!");
    }
}

interface Engine
{
    void Start();
    void Stop();
}

class Car : Engine
{
    public Car() { }

    public void Start()
    {
        Console.WriteLine("Start Engine...");
    }
    public void Stop()
    {
        Console.WriteLine("Stop Engine");
    }
}
