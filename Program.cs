using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;

class Program
{
    static void Main()
    {
        GCSettings.LatencyMode = GCLatencyMode.Interactive;

        // Ambil penggunaan memori sebelum operasi
        long memoryBefore = Process.GetCurrentProcess().WorkingSet64;
        Console.WriteLine($"Memori sebelum operasi: {memoryBefore / 1024} KB");

        // Membuat List of Dictionary
        List<Dictionary<string, string>> listOfDictionaries = new List<Dictionary<string, string>>();

        // Menambahkan beberapa Dictionary ke dalam List
        Dictionary<string, string> dict1 = new Dictionary<string, string>
        {
            { "Name", "John" },
            { "Age", "30" },
            { "City", "New York" }
        };

        Dictionary<string, string> dict2 = new Dictionary<string, string>
        {
            { "Name", "Jane" },
            { "Age", "25" },
            { "City", "Los Angeles" }
        };

        // Menambahkan dictionary ke dalam list
        listOfDictionaries.Add(dict1);
        listOfDictionaries.Add(dict2);

        // Ambil penggunaan memori setelah operasi
        long memoryAfter = Process.GetCurrentProcess().WorkingSet64;
        Console.WriteLine($"Memori setelah operasi: {memoryAfter / 1024} KB");

        // Menampilkan semua dictionary dalam List
        foreach (var dict in listOfDictionaries)
        {
            Console.WriteLine("----- Dictionary -----");
            foreach (var keyValuePair in dict)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            Console.WriteLine();
        }

        // Ambil penggunaan memori setelah menampilkan data
        long memoryFinal = Process.GetCurrentProcess().WorkingSet64;
        Console.WriteLine($"Memori setelah menampilkan data: {memoryFinal / 1024} KB");
    }
}
