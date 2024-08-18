using System;

class Program
{
    static void Main()
    {
        Point point = new();
        point.x = 12;
        point.y = 22;
        int multiple = point.multiple();
        Console.WriteLine(multiple);
    }
}

public struct Point
{
    public int x;
    public int y;


    public int multiple()
    {
        return x * y;
    }
}