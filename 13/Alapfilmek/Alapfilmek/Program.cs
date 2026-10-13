using Filmek_Lib;

Console.WriteLine($"4. feladat: {Datastore.Instance.Alkotok
    .Where(x=>x.szuletett.HasValue)
    .Count(x=>x.szuletett.Value.Year >= 1900 && x.szuletett.Value.Year<2000)} db született a 20. században");

Console.WriteLine($"5. feladat: {Datastore.Instance.Filmek
    .Count(x => 
    Convert.ToInt32(x.ev) == DateTime.Now.Year - 50)} db film ünnepli idén készítésének 50. évfordulóját.");


Console.WriteLine($"6. feladat: Egy tanótán megnézhető filmek:");
List<Filmek> megnezhetofilmek = Datastore.Instance.Filmek.Where(x => x.hossz <= 45).OrderBy(x=>x.hossz).ToList();
foreach (var f in megnezhetofilmek) 
{
    Console.WriteLine($"\t{f.cim} ({f.mufaj}): {f.hossz} perc");
}

Console.Write($"7. feladat: A film címe: ");
string cim = Console.ReadLine()!;
Filmek film = Datastore.Instance.Filmek.FirstOrDefault(x => x.cim == cim)!;

if (film != null)
{
    int rendezooazonosito = Datastore.Instance.Munkakor.First(x => x.munkakor == "Rendező").munkakorazon;


    List<Filmstab> filmstab = Datastore.Instance.Filmstab.Where(x => x.filmazon == film.filmazon).ToList();

    Filmstab keresendoFilmstabos = filmstab.First(x => x.munkakorazon == rendezooazonosito);


    Console.WriteLine($"\tRendező: {Datastore.Instance.Alkotok.First(x=>x.alkotoazon == keresendoFilmstabos.alkotoazon).nev}");
    Console.WriteLine($"\tKészítési év: {film.ev}");
    Console.WriteLine($"\tLink: https://videotorium.hu/hu/recordings/{film.filmazon}");

}
else 
{
    Console.WriteLine("Ilyen néven nem található film.");
}

var ds = Datastore.Instance;

int foszereploAzon = ds.Munkakor
    .First(m => m.munkakor == "Főszereplő")
    .munkakorazon;

var legtobb = ds.Filmstab
    .Where(fs => fs.munkakorazon == foszereploAzon)
    .GroupBy(fs => fs.alkotoazon)
    .OrderByDescending(g => g.Count())
    .Take(2);

foreach (var g in legtobb)
{
    string nev = ds.Alkotok.First(a => a.alkotoazon == g.Key).nev;
    Console.WriteLine($"{nev} ({g.Count()} film)");
}