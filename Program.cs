using System;
using System.Diagnostics;
using System.Runtime;

class Program
{
    static void Main()
    {
        Car lascar = new();
        lascar.Start();
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
