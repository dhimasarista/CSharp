// Pengecekan tipe data
object value = "Hello";
if (value is string str)
{
    Console.WriteLine("Value is a string: " + str);
}
else
{
    Console.WriteLine("Value is not a string");
}
