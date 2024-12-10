class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new();
        string s = "(){}}{";
        var isValid = solution.IsValid(s);
        Console.WriteLine(isValid);
    }

}