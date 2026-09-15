using ClassLibrary1;


string[] Beolvasas = File.ReadAllLines("szszb.csv");

Telepulesek telepulesek = new Telepulesek(Beolvasas);




Console.Write("3. feladat: ");
Console.WriteLine($"Települések száma: {telepulesek.TelepulesekDB()} db");



Console.Write("4. feladat: ");
Console.WriteLine($"Települések átlagos mérete: {telepulesek.AtlagTerulet().ToString("0.0")} ha");



Console.Write("5. feladat: ");
Console.WriteLine($"Térségek: {string.Join(", ", telepulesek.TersegekNevei())}");



Console.Write("6. feladat: ");
Console.Write("Kérem a térség nevét: ");
string tersegNev = Console.ReadLine();

if (telepulesek.LetezoTerseg(tersegNev))
{
    Console.WriteLine($"\tA legnagyobb népsűrűségű település adatai a térségben: ");
    Console.WriteLine($"\tTelepülésnév: {telepulesek.LegnagyobbTelepules(tersegNev).TelepulesNev}");
    Console.WriteLine($"\tRang: {telepulesek.LegnagyobbTelepules(tersegNev).Rang}");
    Console.WriteLine($"\tNépsűrűség: {telepulesek.LegnagyobbTelepules(tersegNev).Nepsuruseg.ToString("0.00")} fő/km2");
}
else
{
    Console.WriteLine("\tA megadott térség nem létezik");
}



Console.Write("7. feladat: ");
Console.WriteLine("Település rangonként a települések száma: ");

foreach (var tipus in telepulesek.TelepulesekSzamaRangonkent())
{
    Console.WriteLine($"\t{tipus.Key}: {tipus.Value}");
}



Console.Write("8. feladat: ");
Console.WriteLine("Település rangonként a települések száma: ");

foreach (var rangTipus in telepulesek.TelepulesekLakossagaRangonkent())
{
    Console.WriteLine($"\t{rangTipus.Key}: {((double)rangTipus.Value / 1000).ToString("0.0")} ezer fő");
}