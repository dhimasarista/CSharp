using System;
using Algorithms;
class Program
{
    static void Main()
    {
        Foo foo = new("Dhimas Arista");
        Bar bar = new(foo);
        bar.DisplayName();
    }
}

// Kelas Foo dengan konstruktor untuk menyuntikkan nama
class Foo
{
    private string name;

    public Foo(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
}

// Kelas Bar dengan konstruktor untuk menyuntikkan objek Foo
class Bar
{
    private Foo foo;

    public Bar(Foo foo)
    {
        this.foo = foo;
    }

    public void DisplayName()
    {
        Console.WriteLine("Foo's name is: " + foo.GetName());
    }
}
