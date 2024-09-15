class Program
{
    private static void Main(string[] args)
    {
        static string GetDay(int day) => day switch
        {
            1 => "Senin",
            2 => "Selasa",
            3 => "Rabu",
            4 => "Kamis",
            5 => "Jumat",
            6 => "Sabtu",
            7 => "Minggu",
            _ => "Hari tidak valid"
        };

        DateTime today = DateTime.Now;
        int dayOfWeekNumber = (int)today.DayOfWeek;
        Console.WriteLine($"Hari ini, hari {GetDay(dayOfWeekNumber)}");
    }
}