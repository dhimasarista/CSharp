using System;
using System.Collections.Generic;

class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}

class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Dog barks");
}

class Program
{
    static void Main()
    {
        // Array of Dogs
        Dog[] dogs = new Dog[] { new Dog(), new Dog() };

        // Covariance: IEnumerable<Dog> can be assigned to IEnumerable<Animal>
        IEnumerable<Animal> animals = dogs;

        foreach (Animal animal in animals)
        {
            animal.Speak();  // Calls Dog's Speak method
        }
    }
}
