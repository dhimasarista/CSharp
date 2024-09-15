string GetDayType(int day) => day switch
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

var x = GetDayType(1);
Console.WriteLine(x);