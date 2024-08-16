using System;

class Program
{
    static void Main()
    {
        // Mendefinisikan dua bilangan bulat
        int number1 = 10; // 1010 dalam biner
        int number2 = 5;  // 0101 dalam biner

        // Melakukan operasi XOR
        int result = number1 ^ number2;

        // Menampilkan hasil operasi XOR
        Console.WriteLine($"Hasil XOR dari {number1} dan {number2} adalah: {result}");

        // Menampilkan hasil dalam biner
        Console.WriteLine($"Dalam biner: {Convert.ToString(number1, 2)} ^ {Convert.ToString(number2, 2)} = {Convert.ToString(result, 2)}");
    }
}
