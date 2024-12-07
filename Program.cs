using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public interface IUserService
{
    Dictionary<string, string> CreateUser(string username, string password);
    bool DeleteUser(string username);
    List<Dictionary<string, string>> ShowUsers();
}

public class UserService : IUserService
{
    private List<Dictionary<string, string>> users = new List<Dictionary<string, string>>();

    public Dictionary<string, string> CreateUser(string username, string password)
    {
        var user = new Dictionary<string, string>
        {
            { "user_id", new Random().Next(10, 20).ToString() },
            { "username", username },
            { "password", HashPassword(password) }
        };
        users.Add(user);
        return user;
    }

    public bool DeleteUser(string username)
    {
        var user = users.FirstOrDefault(u => u["username"] == username);
        if (user != null)
        {
            users.Remove(user);
            return true;
        }
        return false;
    }

    public List<Dictionary<string, string>> ShowUsers()
    {
        return users;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}

public class UserController
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    public Dictionary<string, string> Create(string username, string password)
    {
        return userService.CreateUser(username, password);
    }

    public bool Delete(string username)
    {
        return userService.DeleteUser(username);
    }

    public List<Dictionary<string, string>> All()
    {
        return userService.ShowUsers();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var userController = new UserController(new UserService());

        userController.Create("dhimasarista", "hellophp8");
        userController.Create("anto", "hellophp8");
        userController.Create("ujang", "hellophp8");

        Console.WriteLine("All users:");
        foreach (var user in userController.All())
        {
            Console.WriteLine(string.Join(", ", user.Select(kv => $"{kv.Key}: {kv.Value}")));
        }

        Console.WriteLine("\nDeleting 'anto'...");
        userController.Delete("anto");

        Console.WriteLine("All users after deletion:");
        foreach (var user in userController.All())
        {
            Console.WriteLine(string.Join(", ", user.Select(kv => $"{kv.Key}: {kv.Value}")));
        }
    }
}
