using ClassLibrary1;
using System.Globalization;
using System.Reflection;

Kiralyok kiralyok = new Kiralyok(beolvasas("uralkodo.csv").ToList());



Console.WriteLine("2. feladat: A 14-edik században megkoronázott uralkodók:");
foreach (var item in kiralyok.tizen4edik)
{
    Console.WriteLine($"\t{item.nev.PadRight(14)} {item.mettol} {item.meddig}");
}
Console.WriteLine($"3. feladat: Magyar királyok:");
foreach (var item in kiralyok.magyarKiralyokEgyszer)
{
    Console.WriteLine($"\t{item.nev} ({item.ragnev}) {item.mettol}");
}

Console.WriteLine("4. feladat: Fiatal uralkodók:");
foreach (var item in kiralyok.fiatal)
{
    int kor = item.mettol - item.szul;
    Console.WriteLine($"\t{item.nev.PadRight(14)}{(kor <= 1 ? "újszülött" : kor)}");

}

Console.WriteLine("5. feladat: hosszú uralkodás:");
foreach (var item in kiralyok.hosszú)
{
    int ev = item.meddig - item.mettol;
    Console.WriteLine($"\t{item.nev.PadRight(14)} {(string.IsNullOrWhiteSpace(item.ragnev) ? "" : item.ragnev)} {ev} év");
}

Console.WriteLine("6. feladat: Uralkodó háztak:");
foreach (var item in kiralyok.uhaz)
{
    foreach (var asd in item) {
        Console.WriteLine($"\t{asd.Key} {asd.Value} király");
    }
}

Console.WriteLine("7. feladat: Koronázás előtt már uralkodó:");
foreach (var item in kiralyok.kelott)
{
    Console.WriteLine($"\t{item}");
}

using (var writer = new StreamWriter("melleknev.txt"))
{
    foreach (var kiraly in kiralyok.uralkodokRagadvannyal)
    {
        string koronazasEv = kiraly.koronazas.HasValue ? kiraly.koronazas.Value.ToString() : "-";
        writer.WriteLine($"{kiraly.nev} ({kiraly.ragnev}) {koronazasEv}");
    }
}











static IEnumerable<Kiraly> beolvasas(string f) 
{
    foreach (var intem in File.ReadLines(f).Skip(1))
    {
        string[] sor = intem.Split(';');

        yield return new Kiraly(
           Convert.ToInt32(sor[0]),
           sor[1],
           sor[2] == "" ? null : sor[2],
           Convert.ToInt32(sor[3]),
           Convert.ToInt32(sor[4]),
           sor[5],
           Convert.ToInt32(sor[6]),
           Convert.ToInt32(sor[7]),
           sor[8] == "" ? null : Convert.ToInt32(sor[7])
        );
    }

}

