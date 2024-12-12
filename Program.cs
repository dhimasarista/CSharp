using System;

class Program
{
    static void Main()
    {
        var startTime = DateTime.Now.Ticks;

        var counter = 0;
        for (var i = 0; i <= 999; i++)
        {
            for (var j = 0; j <= 999; j++)
            {
                for (var k = 0; k <= 999; k++)
                {
                    for (var l = 0; l <= 4; l++)
                    {
                        counter++;
                    }
                }
            }
        }

        var endTime = DateTime.Now.Ticks;
        var executionTime = (endTime - startTime) / TimeSpan.TicksPerMillisecond;
        Console.WriteLine($"Total iterations: {counter}");
        Console.WriteLine($"Execution time: {executionTime} ms");
    }
}