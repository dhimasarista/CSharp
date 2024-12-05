using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachineOOP
{
    // Interface untuk Logger
    public interface ILogger
    {
        void Log(string message);
    }

    // Abstract class: Mesin dasar
    public abstract class CoffeeMachine
    {
        public string Brand { get; private set; }
        public bool IsOn { get; private set; }

        protected CoffeeMachine(string brand)
        {
            Brand = brand;
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Brand} Coffee Machine is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Brand} Coffee Machine is now OFF.");
        }

        public abstract Task MakeCoffeeAsync(string coffeeType); // Abstract method
    }

    // Class Turunan: Mesin Kopi Otomatis
    public class AutomaticCoffeeMachine : CoffeeMachine, ILogger
    {
        private readonly List<string> _coffeeMenu = new() { "Espresso", "Latte", "Cappuccino" };

        public AutomaticCoffeeMachine(string brand) : base(brand) { }

        // Implementasi abstract method
        public override async Task MakeCoffeeAsync(string coffeeType)
        {
            if (!IsOn)
            {
                throw new InvalidOperationException("The coffee machine is OFF. Please turn it ON first.");
            }

            if (!_coffeeMenu.Contains(coffeeType))
            {
                throw new ArgumentException($"Coffee type '{coffeeType}' is not available.");
            }

            Console.WriteLine($"Preparing your {coffeeType}...");
            await Task.Delay(2000); // Simulasi pembuatan kopi
            Console.WriteLine($"{coffeeType} is ready! Enjoy your coffee.");
        }

        // Implementasi Interface ILogger
        public void Log(string message)
        {
            Console.WriteLine($"[Log] {message}");
        }
    }

    // Class Generik untuk Penyimpanan Data (seperti daftar pesanan kopi)
    public class CoffeeOrderRepository<T> where T : class
    {
        private readonly List<T> _orders = new();

        public void AddOrder(T order)
        {
            _orders.Add(order);
            Console.WriteLine($"Order '{order}' added.");
        }

        public IEnumerable<T> GetOrders()
        {
            return _orders;
        }
    }

    // Custom Exception
    public class CoffeeMachineException : Exception
    {
        public CoffeeMachineException(string message) : base(message) { }
    }

    // Program Utama
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                // Membuat mesin kopi otomatis
                AutomaticCoffeeMachine coffeeMachine = new("CoffeeMaster 3000");

                // Menghidupkan mesin kopi
                coffeeMachine.TurnOn();

                // Membuat kopi (Async)
                await coffeeMachine.MakeCoffeeAsync("Latte");

                // Menyimpan pesanan ke repositori
                var coffeeOrderRepo = new CoffeeOrderRepository<string>();
                coffeeOrderRepo.AddOrder("Latte");

                // Menampilkan semua pesanan
                Console.WriteLine("All Orders:");
                foreach (var order in coffeeOrderRepo.GetOrders())
                {
                    Console.WriteLine($"- {order}");
                }

                // Logging
                coffeeMachine.Log("Latte was successfully prepared.");

                // Mematikan mesin kopi
                coffeeMachine.TurnOff();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid Operation: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }
    }
}
