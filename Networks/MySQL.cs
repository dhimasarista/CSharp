using MySql.Data.MySqlClient;

namespace Networks;

class MySQL
{
    public MySQL(string dbName, string tableName)
    {
        string connectionString = $"server=localhost;user=root;database={dbName}";

        // Membuat koneksi ke database
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                // Buka koneksi
                connection.Open();

                // Query SQL
                string query = $"SELECT * FROM {tableName}";

                // Membuat perintah SQL
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Membaca data hasil query
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Menampilkan data
                            Console.WriteLine(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
