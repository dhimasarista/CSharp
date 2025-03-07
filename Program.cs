using System;


class Program
{
    public static void Main(string[] args)
    {
        // Alokasikan banyak objek
        for (int i = 0; i < 100000; i++)
        {
            var obj = new object();
        }
        Console.WriteLine("Sebelum GC.Collect");
        Console.WriteLine($"Memori yang digunakan: {GC.GetTotalMemory(false)} bytes");

        // Memanggil GC secara manual
        GC.Collect();
        GC.WaitForPendingFinalizers(); // Tunggu semua finalizer selesai (opsional)
        GC.Collect(); // Pastikan semua yang bisa dikoleksi sudah terkoleksi

        Console.WriteLine("Setelah GC.Collect");
        Console.WriteLine($"Memori yang digunakan: {GC.GetTotalMemory(false)} bytes");
    }
}