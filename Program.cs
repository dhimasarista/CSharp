class Program
{
    public static void Main(string[] args)
    {
        var names = new List<string> { "dhimasarista", "anto" };
        var hello = new Hello(names.ToArray());
        string[] getData = hello.GetData();

        foreach (var data in getData)
        {
            Console.WriteLine(data);
        }
    }
}

struct Hello
{
    private string[] data;
    public Hello(string[] data)
    {
        this.data = data;
    }

    public readonly string[] GetData()
    {
        return this.data;
    }
}