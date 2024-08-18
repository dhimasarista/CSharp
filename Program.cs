using System;

class Program
{
    static void Main()
    {
        Point point = new(12, 22);
        
        int multiple = point.multiple();
        Console.WriteLine(multiple);
    }
}

public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y){
        this.x = x;
        this.y = y;
    }

    public int multiple()
    {
        return x * y;
    }
}
