var numbers = new List<int>();
var semaphore = new SemaphoreSlim(1);
Parallel.For(0, 10, i =>
{
    semaphore.Wait();
    numbers.Add(i);
    semaphore.Release();
});
foreach (var x in numbers)
{
    Console.WriteLine(x);
}