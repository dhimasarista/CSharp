var data = new List<string>{ "a", "b", "c" };
// Method Reference
data.ForEach(Console.WriteLine);

// Cara Biasa
data.ForEach((string d) =>
{
    Console.WriteLine(d);
});