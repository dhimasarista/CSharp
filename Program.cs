using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Program
{
    static async Task<List<string>> QueryDBAsync(MySqlConnection db)
    {
        var results = new List<string>();
        string query = "SELECT username FROM users";

        try
        {
            await db.OpenAsync(); // Membuka koneksi ke database

            using (var cmd = new MySqlCommand(query, db))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        results.Add(reader.GetString(0)); // Menambahkan hasil ke list
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            await db.CloseAsync(); // Menutup koneksi setelah selesai
        }

        return results;
    }

    static async Task Main(string[] args)
    {
        string connectionString = "server=localhost;port=3306;user=root;database=product_go;";
        var db = new MySqlConnection(connectionString);

        // Mencatat waktu sebelum query
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Menjalankan query ke database
        List<string> results = await QueryDBAsync(db);

        // Menghitung waktu eksekusi
        stopwatch.Stop();

        // Menampilkan hasil
        Console.WriteLine("Results:");
        foreach (var name in results)
        {
            Console.WriteLine(name);
        }

        // Menampilkan durasi waktu
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
}
