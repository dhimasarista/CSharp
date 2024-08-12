class Program
{
    public static void Main(string[] args)
    {
        var dhimas = new Programmer("Dhimas Arista");
        dhimas.AddLanguage("C#");
        dhimas.AddLanguage("Javascript");
        dhimas.ShowLanguages();
    }
}

class Programmer
{
    private List<dynamic> _languages = [];
    private string _name = "";
    public Programmer(string name)
    {
        this._name = name;

        Console.WriteLine($"Hello, {_name}");
    }

    public void AddLanguage(string language)
    {
        _languages.Add(language);
    }

    public void ShowLanguages()
    {
        Console.WriteLine("My Languages:");
        foreach (var language in _languages)
        {
            Console.WriteLine($" - {language}");
        }
    }
}