using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Menyaring bilangan genap
        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num); // Output: 2, 4, 6, 8, 10
        }
    }
}