using ClassLibrary1;
using System.Reflection.Metadata;
using System.IO;


Console.WriteLine("1a. feladat");


int? lekerendo;


do
{
    Console.Write("Hanyadik csoport teszt eredményét szeretnéd lekérni (1/2): ");

    string sor = Console.ReadLine();

    if (int.TryParse(sor, out int szam))
    {
        lekerendo = szam;
    }
    else
    {
        Console.WriteLine("nincs ilyen csoport");
        lekerendo = null;
    }

} while (lekerendo != 1 && lekerendo != 2);


var allLines = File.ReadAllLines($"csoport{lekerendo}.csv");
if (allLines.Length <= 2)
{
    Console.WriteLine($"A csopot nem írta meg a tesztet");
}
else
{
    Tesztek Tesztek_csoprt = new Tesztek(Beolvasas(lekerendo));

    Console.WriteLine("");

    Console.WriteLine("1c. feladat");

    Console.WriteLine($"{Tesztek_csoprt.nemIrtaMeg} tanuló nem írta meg.");

    Console.WriteLine("");

    Console.WriteLine("2. feladat");
    Console.Write($"Név: ");
    string nev = Console.ReadLine();
    Teszt? keresendo = Tesztek_csoprt[nev];
    if (keresendo == null)
    {
        Console.WriteLine("Nincs ilyen nevű tanuló a csoportban");
    }
    else
    {
        Console.WriteLine($"{nev} nevű tnuló tesztjei: " +
            $"{keresendo.Elso?.ToString() ?? "-"} | " +
            $"{keresendo.Masodik?.ToString() ?? "-"} | " +
            $"{keresendo.Harmadik?.ToString() ?? "-"} | " +
            $"{keresendo.Negyedik?.ToString() ?? "-"} | " +
            $"{keresendo.Otodik?.ToString() ?? "-"} | " +
            $"{(keresendo.Elso ?? 0) + (keresendo.Masodik?? 0) + (keresendo.Harmadik?? 0) + (keresendo.Negyedik?? 0) + (keresendo.Otodik?? 0)}");


    }

    Console.WriteLine("");
    Console.WriteLine("3. feladat");
    Console.WriteLine($"Az egyes feladat megoldásainka száma: {Tesztek_csoprt.elsoFeladat}");
    Console.WriteLine($"Egyes átlagos pontszáma: {Tesztek_csoprt.elsoAtlag()}");
    Console.WriteLine($"Az egyes feladatot üresen hagyók száma: {Tesztek_csoprt.elsoUres}");

    Console.WriteLine("");
    Console.WriteLine("4. feladat");

    Tesztek_csoprt.MentesSzazalekCsv(lekerendo.Value);

    Console.WriteLine($"szazalek{lekerendo}.csv fájl elkészült.");











}










static IEnumerable<Teszt> Beolvasas(int? lekerendo) 
{
    foreach (var line in File.ReadLines($"csoport{lekerendo}.csv").Skip(1))
    {
        var parts = line.Split(';');
        yield return new Teszt(
            string.IsNullOrWhiteSpace(parts[0])? null : parts[0],
            int.TryParse(parts[1], out var elso) ? elso : null,
            int.TryParse(parts[2], out var masodik) ? masodik : null,
            int.TryParse(parts[3], out var harmadik) ? harmadik : null,
            int.TryParse(parts[4], out var negyedik) ? negyedik : null,
            int.TryParse(parts[5], out var otodik) ? otodik : null
            );
    }
}

