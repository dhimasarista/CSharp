using System;
using System.IO;
using System.Reflection;
// Dapatkan assembly saat ini
        var assembly = Assembly.GetExecutingAssembly();

        // Nama file resource - gunakan namespace lengkap + nama file
        string resourceName = "CSharp.Sample.txt"; // Sesuaikan dengan namespace Anda

        // Buka stream untuk membaca resource
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
            else
            {
                Console.WriteLine("Resource tidak ditemukan.");
            }
        }