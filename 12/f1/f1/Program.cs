using ClassLib;

Console.WriteLine("Hello, World!");

Versenyek versenyek = new Versenyek(Beolvasas());


Console.WriteLine("2. feladat: hill nevűek:");
foreach (var item in versenyek.HillPilóták) {
    Console.WriteLine($"\t{item.nev} ({item.nemzet}) {item.szuldat} ");
}

Console.WriteLine($"3. feladat: futamgyőztesek:");
foreach (var item in versenyek.Futamgyőztesek)
{
    Console.WriteLine($"\t{item.nev}");
}

Console.WriteLine($"4. feladat: Juan-Manuel Fanigo {versenyek.JuanKor ?? 0} éves volt az első versenyén");


Console.WriteLine("5. feladat: Ferrariknál a 3 leggyakoribb hiba:");
foreach (var dict in versenyek.ferrari3)
{
    foreach (var elem in dict)
    {
        Console.WriteLine($"\t{elem.Key}: {elem.Value} alkalommal");
    }
}

Console.WriteLine($"6. feladat: {versenyek.NincsCsapat} olyan versenyző volt akinek valamelyik versenyen nem volt csapata");


Console.WriteLine("7. feladat: Magyarország után rendezték az első nagydíjukat:");
Console.WriteLine(string.Join(", ", versenyek.OrszagokAzElsoMagyarUtán));


versenyek.WriteFile("monaco.txt", "Monaco");


static IEnumerable<Verseny> Beolvasas()
{
    foreach (var item in File.ReadAllLines("eredmenyek.csv").Skip(1))
    {
        var p = item.Split(';');

        yield return new Verseny(
            DateOnly.Parse(p[0]),
            p[1],
            p[2],
            p[3],
            string.IsNullOrWhiteSpace(p[4]) ? null : DateOnly.Parse(p[4]),
            p[5],
            int.TryParse(p[6], out var helyezes) ? helyezes : 0,
            string.IsNullOrWhiteSpace(p[7]) ? null : p[7],
            p[8],
            p[9],
            p[10]
        );
    }
}


