class Program
{
    public static void Main(string[] args)
    {
    }
}

public struct Point : IPoint
{
    // Display Wajib Di Wariskan Dari IPoint Ke Point
    public void Display() { }
}

// Kontrak Struct Dengan Interface
interface IPoint { void Display(); }