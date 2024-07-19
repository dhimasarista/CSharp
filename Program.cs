using System;
using System.Threading.Tasks;

class Program
{

    public static async Task Main(string[] args)
    {
        Console.WriteLine(args[0]);
        await Task.Delay(1000);
        Console.WriteLine(args[1]);
    }
}