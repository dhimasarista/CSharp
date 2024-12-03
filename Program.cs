using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        // Membuat data besar
        int totalRecords = 100000000;
        var data = Enumerable.Range(1, totalRecords).ToList();

        Stopwatch stopwatch = Stopwatch.StartNew();

        // Parallel async processing (simulasi query SQL)
        var sumResult = await Task.WhenAll(data.Select(async number =>
        {
            return await Task.Run(() => ProcessData(number));
        }));

        stopwatch.Stop();

        Console.WriteLine($"Total Sum: {sumResult.Sum()}", stopwatch.ElapsedMilliseconds);
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static int ProcessData(int number)
    {
        // Simulasi proses data seperti query
        return number % 2 == 0 ? number : 0;
    }
}
