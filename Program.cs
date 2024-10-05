using System;
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

                // Eksekusi query untuk mengambil kolom id dan name saja
                string query = "SELECT id, name FROM tps";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Parsing hasil query
                        while (await reader.ReadAsync())
                        {
                            string id = reader["id"]?.ToString() ?? "null";
                            string name = reader["name"]?.ToString() ?? "null";
                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
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
