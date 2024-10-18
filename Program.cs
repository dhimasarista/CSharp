public struct Point {
    // Properties
    public int X;
    public int Y;

    // Constructor
    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    // Method
    public void Display() {
        Console.WriteLine($"X: {X}, Y: {Y}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point point = new();
        point.X = 12;
        point.Y = 22;

        Console.WriteLine(point.X);
    }
}