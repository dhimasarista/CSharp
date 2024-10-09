class Program {
    public static void Main(){
        var numbers = new List<int>();
        Parallel.For(0, 10, i => {
            numbers.Add(i);
        });

        foreach (var item in numbers)
        {
            Console.WriteLine(item); 
        }
    }
}