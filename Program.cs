string GetDayType(int day) => day switch
{
<<<<<<< HEAD
    1 => "Senin",
    2 => "Selasa",
    3 => "Rabu",
    4 => "Kamis",
    5 => "Jumat",
    6 => "Sabtu",
    7 => "Minggu",
    _ => "Hari tidak valid"
};

var x = GetDayType(1);
Console.WriteLine(x);
=======
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

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int multiple()
    {
        return x * y;
    }
}
>>>>>>> 51d114e729bd37037d1ca3b5601d46c0c18779ba
