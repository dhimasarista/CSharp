using System;

class Program
{
    static void Main()
    {
        // Mendefinisikan dua variabel
        int a = 5;
        int b = 10;

        // Menampilkan nilai awal
        Console.WriteLine($"Sebelum swap: a = {a}, b = {b}");

        // Menukar nilai menggunakan XOR
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;

        // Menampilkan hasil setelah swap
        Console.WriteLine($"Setelah swap: a = {a}, b = {b}");
    }
}
