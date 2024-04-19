// Tentukan jumlah iterasi
int iterations = 10;

// Gunakan Parallel.For untuk melakukan looping secara paralel
Parallel.For(0, iterations, i =>
{
    Console.WriteLine($"Task {Task.CurrentId} is processing iteration {i}");
    // Tambahan logika bisnis di sini
});

Console.WriteLine("Looping selesai.");