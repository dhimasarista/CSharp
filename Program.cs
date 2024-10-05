<<<<<<< HEAD
var person = new
{
    Name = "Dhimas Arista",
    Age = 22,
};

Console.WriteLine(person.Name);
=======
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Program
{
    static async Task Main()
    {
        // Koneksi ke MySQL
        string connectionString = "Server=127.0.0.1;Database=rekra_dev;User ID=probanteng;Password=Merdeka2024;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();

                // Hitung waktu mulai menggunakan Stopwatch
                var stopwatch = Stopwatch.StartNew();

                // Eksekusi query untuk mengambil kolom id dan name
                string query = "SELECT id, name FROM tps";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // List untuk menyimpan tugas parsing
                        var tasks = new List<Task>();

                        // Parsing hasil query
                        while (await reader.ReadAsync())
                        {
                            // Mengambil data di setiap iterasi
                            string id = reader["id"]?.ToString() ?? "null";
                            string name = reader["name"]?.ToString() ?? "null";

                            // Menambahkan tugas ke list
                            tasks.Add(Task.Run(() => 
                                Console.WriteLine($"ID: {id}, Name: {name}");
                            {
                            }));
                        }

                        // Menunggu semua tugas selesai
                        await Task.WhenAll(tasks);
                    }
                }

                // Hitung waktu selesai
                stopwatch.Stop();
                Console.WriteLine($"Execution time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
>>>>>>> 825faa856c84b4847c491a0538fe11c7fcf9571c
