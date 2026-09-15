// See https://aka.ms/new-console-template for more information
using Cseveges;

Console.WriteLine("Hello, World!");


List<Beszelgetes> beszelgetesek =  new List<Beszelgetes>();

foreach (var sor in File.ReadLines("csevegesek.txt").Skip(1)) 
{
    beszelgetesek.Add(new Beszelgetes(sor));
}


List<string> tagok = new List<string>();

foreach (var sor in File.ReadLines("Tagok.txt").Skip(1)) 
{
    tagok.Add(sor);
}

Console.WriteLine($"4. feladat: Tagok száma: {tagok.Count()}fő - Beszélgetések: {beszelgetesek.Count()}db");

Console.WriteLine("5. feladat: Leghosszabb beszélgetés adatai:");
var leghosszabb = beszelgetesek.MaxBy(x => x.veg - x.kezdet);

Console.WriteLine($"\tKezdeményező:\t{leghosszabb.kezdemenyezo}");
Console.WriteLine($"\tFogadó:\t\t{leghosszabb.fogado}");
Console.WriteLine($"\tKezdet:\t\t{leghosszabb.kezdet}");
Console.WriteLine($"\tVége:\t\t{leghosszabb.veg}");
Console.WriteLine($"\tKezdeményező:\t{(leghosszabb.veg - leghosszabb.kezdet).TotalSeconds}mp");

Console.Write($"6. feladat: Adja meg egy tag nevét: ");
string tag = Console.ReadLine();

var osszido = TimeSpan.FromSeconds(beszelgetesek.Where(x => x.kezdemenyezo == tag || x.fogado == tag).Sum(x => (x.veg - x.kezdet).TotalSeconds));

Console.WriteLine($"A beszélgatések összes ideje: {osszido.Hours:D2}:{osszido.Minutes}:{osszido.Seconds}");



Console.WriteLine("7. feladat: nem beszélt senkivel");

List<string> nemBeszelt = tagok.Where(tag => !beszelgetesek.Any(b => b.kezdemenyezo == tag || b.fogado == tag)).ToList();

foreach (string e in nemBeszelt) 
{ 
    Console.WriteLine($"\t{e}");
}

Console.WriteLine($"8. feladat: Leghoszabb csendes időszak 15h-tól");

var rendezett = beszelgetesek.OrderBy(b => b.kezdet).ToList();

TimeSpan maxCsend = TimeSpan.Zero;
DateTime csendKezd = DateTime.MinValue;
DateTime csendVeg = DateTime.MinValue;

for (int i = 0; i < rendezett.Count - 1; i++)
{
    var csend = rendezett[i + 1].kezdet - rendezett[i].veg;
    if (csend > maxCsend)
    {
        maxCsend = csend;
        csendKezd = rendezett[i].veg;
        csendVeg = rendezett[i + 1].kezdet;
    }
}


Console.WriteLine($"\tKezdete: {csendKezd}");
Console.WriteLine($"\tVége: {csendVeg}");
Console.WriteLine($"\tHossza: {maxCsend}");
