using ClassLib;
using System.Runtime.CompilerServices;

Console.WriteLine($"4. feladat: {DataStore.Instance.Urhajok.Count(x=>x.UrhajoNev.Contains("Enterprise"))} darab űrhajó nevében szerepel az \"Enterprise\" szó");

Console.Write("5. feladat: A szerep neve: ");
string? szerep = Console.ReadLine();
int szerep_Db = DataStore.Instance.HajoSzerepek.Count(x => x.SzerepNev == szerep);

if (szerep_Db == 0)
{
    Console.WriteLine($"\t Ilyen szerep nincs az adatbázisban.");
}
else
{
    Console.WriteLine($"\t {szerep_Db} hajóosztály rendeltetée a megadott szerep.");
}

Console.WriteLine("6. ferladat:");
var urhajokOsztalySzerint = DataStore.Instance.Urhajok.GroupBy(x => x.OsztalyID).Select(x => (DataStore.Instance.HajoOsztalyok.FirstOrDefault(y => y.OsztalyID == x.Key)!.OsztalyNev, x.Count())).OrderByDescending(x=>x.Item2).Take(3);
foreach (var x in urhajokOsztalySzerint)
{
    Console.WriteLine($"\t{x.Item1}: {x.Item2} űrhajó");
} 
