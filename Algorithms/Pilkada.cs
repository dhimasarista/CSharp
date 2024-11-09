namespace Algorithms;

public class Pilkada {
    public static void Batam(){
        // Data Pilkada 2020
        int jumlahPemilihTerdaftar2020 = 587527;
        int suaraCalon1_2020 = 267299;
        int suaraCalon2_2020 = 98887;
        int jumlahPemilihAktif2020 = suaraCalon1_2020 + suaraCalon2_2020; // Suara yang diberikan
        double persentaseCalon1_2020 = ((double)suaraCalon1_2020 / jumlahPemilihAktif2020) * 100;
        double persentaseCalon2_2020 = ((double)suaraCalon2_2020 / jumlahPemilihAktif2020) * 100;

        Console.WriteLine("Hasil Pilkada 2020:");
        Console.WriteLine($"Jumlah Pemilih Terdaftar: {jumlahPemilihTerdaftar2020:N0}");
        Console.WriteLine($"Jumlah Pemilih yang Berpartisipasi: {jumlahPemilihAktif2020:N0} ({(double)jumlahPemilihAktif2020 / jumlahPemilihTerdaftar2020 * 100:F2}%)");
        Console.WriteLine($"Calon 1 mendapatkan {suaraCalon1_2020:N0} suara ({persentaseCalon1_2020:F2}%)");
        Console.WriteLine($"Calon 2 mendapatkan {suaraCalon2_2020:N0} suara ({persentaseCalon2_2020:F2}%)\n");

        // Data Pilkada 2024
        int jumlahPemilihTerdaftar2024 = 899666;

        // Probabilitas Pemilih yang Berpartisipasi dalam 5 skenario (dalam persen)
        double[] probabilitasPartisipasi = { 60, 65, 70, 75, 80 };

        Console.WriteLine("Prediksi Pemenangan Pilkada 2024 Berdasarkan Probabilitas Partisipasi Pemilih:\n");

        // Looping untuk setiap skenario probabilitas partisipasi pemilih
        foreach (double partisipasi in probabilitasPartisipasi)
        {
            // Menghitung jumlah pemilih yang ikut memilih dalam Pilkada 2024 berdasarkan skenario partisipasi
            int jumlahPemilihAktif = (int)(jumlahPemilihTerdaftar2024 * (partisipasi / 100));

            // Menghitung jumlah suara yang diperlukan oleh masing-masing calon agar menang
            double suaraMenang = jumlahPemilihAktif / 2.0; // Untuk menang, calon harus mendapatkan lebih dari 50% suara

            Console.WriteLine($"Skenario {partisipasi}% Pemilih Berpartisipasi:");
            Console.WriteLine($"Jumlah Pemilih Aktif: {jumlahPemilihAktif:N0}");

            // Menampilkan berapa suara yang harus didapatkan oleh masing-masing calon untuk menang
            Console.WriteLine($"Calon 1 harus mendapatkan lebih dari {suaraMenang:N0} suara untuk menang.");
            Console.WriteLine($"Calon 2 harus mendapatkan lebih dari {suaraMenang:N0} suara untuk menang.");
            Console.WriteLine();
        }
    }
}