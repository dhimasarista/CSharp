unsafe class Program
{
    public static void Main(string[] args)
    {
        int x = 0;
        Console.WriteLine($"sebelum operasi: {x}"); // 0
        ChangeValue(&x);
        Console.WriteLine($"sesudah operasi: {x}"); // 10
    }

    static void ChangeValue(int* x)
    {
        try
        {
            Console.Write("Input Number: ");
            string input = Console.ReadLine() ?? "0";
            *x = int.Parse(input);
        }
        catch (Exception e)
        {
            throw e.GetBaseException();
        }
    }
}