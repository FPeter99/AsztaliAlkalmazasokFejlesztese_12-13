using Nyelviskola_Lib;


DataStore.InitCSV();
DataStore.Instance!.ExportToJson();

Console.WriteLine($"6. feladat: " +
    $"{DataStore.Instance.TanitasiAlkalmak.Count(x=>x.AdottHonapbanVane(2023, 4))}" +
    $" alkalmat jegyeztek fel 2023. áprilisában");

Console.Write("7. feladat: A tanár neve: ");
var nev = Console.ReadLine();
var keresettTanar = DataStore.Instance.Tanarok.FirstOrDefault(x => x.Nev == nev);
if (keresettTanar is null)
{
    Console.WriteLine("\tIlyen néven nem található tanár");
}
else {
    Console.WriteLine($"\tTelefon: {keresettTanar.Telefon}");
    Console.WriteLine($"\tEmail: {keresettTanar.Email}");
}

Console.WriteLine($"8. feladat: A 3 legtöbb órát tanító tanár:");

var tanar_orak = DataStore.Instance.TanitasiAlkalmak
    .GroupBy(x => x.TanarId)
    .ToDictionary(
        g => DataStore.Instance.Tanarok.First(t => t.TanarId == g.Key).Nev,
        g => g.Count()
    ).OrderByDescending(x=>x.Value).Take(3).ToList();
for (int i = 0; i < 3; i++)
{
    var tanarNyelvId = DataStore.Instance.Tanarok.FirstOrDefault(x=>x.Nev == tanar_orak[i].Key).NyelvID;
    Console.WriteLine($"{tanar_orak[i].Key}" +
        $" ({DataStore.Instance.Nyelvek.FirstOrDefault(x=>x.NyelvID == tanarNyelvId).NyelvNev}):" +
        $" {tanar_orak[i].Value} alkalom");
}

Console.WriteLine($"9. feladat: A 3 legtöbbet keteső tanár:");


var tanar_penz = DataStore.Instance!.TanitasiAlkalmak
    .GroupBy(x => x.TanarId)
    .Select(g =>
    {
        var tanar = DataStore.Instance!.Tanarok.First(t => t.TanarId == g.Key);
        return (Nev: tanar.Nev, Penz: g.Count() * tanar.Oradij);
    })
    .OrderByDescending(x => x.Penz)
    .Take(3);

foreach (var t in tanar_penz)
{
    Console.WriteLine($"{t.Nev}: {t.Penz} Ft");
}