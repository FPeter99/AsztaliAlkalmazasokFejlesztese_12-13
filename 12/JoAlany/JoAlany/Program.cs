using ClassLibrary1;
using System;

Nyilvantartas szemelyek = Beolvasas("input.txt");

foreach (var szemely in szemelyek.szemelyekAdatai)
{
    try
    {
        Console.WriteLine(szemely.ToString()); ;
    }
    catch
    {
        throw new Exception();
    }
}

Console.WriteLine($"Diákok száma: {szemelyek.DiakokSzama}");
Console.WriteLine($"Tanárok száma: {szemelyek.TanarokSzama}");
Console.WriteLine($"Tanárok átlagos életkora: {szemelyek.AtlagTanarEletkor}");

foreach (var cheats in szemelyek.DiakokSzamaPuskakSzamaSzerint)
{
    Console.WriteLine($"{cheats.Key} db csalás: {string.Join(", ", cheats.Value)}");
}

Nyilvantartas Beolvasas(string file)
{
    try
    {
        Nyilvantartas szemely = new Nyilvantartas(File.ReadAllLines(file));
        return szemely;
    }
    catch
    {
        throw new Exception();
    }
}