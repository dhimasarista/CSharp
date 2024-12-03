using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Mulai menghitung waktu eksekusi
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int counter = 0;

        // Loop 4 tingkat
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                for (int k = 0; k < 1000; k++)
                {
                    for (int l = 0; l < 5; l++)
                    {
                        counter++;
                    }
                }
            }
        }

        // Menghitung waktu eksekusi
        stopwatch.Stop();

        // Menampilkan waktu eksekusi dan jumlah iterasi
        Console.WriteLine($"Execution Time: {stopwatch.Elapsed.TotalSeconds:F6} seconds");
        Console.WriteLine($"Iterations: {counter}");
    }
}
