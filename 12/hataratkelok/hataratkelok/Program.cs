using ClassLibrary1;


Hataratkelok hataratkelok = new(Beolvasas());


Console.WriteLine($"1. feladat:\nA fájl adatainak száma: {hataratkelok.sorok_szama}\n");

Console.WriteLine($"2. feladat:\nA vasúti átkelők száma: {hataratkelok.vasuti_hataratkelo}\n");

Console.WriteLine("3. feladat:");
foreach (var item in hataratkelok.megyei_jogu_varos)
{
    Console.WriteLine($"{item.Telepules_nev} - {item.Szomszed_telepules}: {item.Atkelo_tipus}");
}
Console.WriteLine();

Console.WriteLine("4. feladat:");
Console.WriteLine($"Ausztriába vezető határátkelő helyek száma: {hataratkelok.ausztriaba_vezeto_hataratkelo}\n");

Console.WriteLine("5. feladat:");
Console.WriteLine($"Ábécében az első olyan település, amelyikből határátkelp vezet Ausztriába: {hataratkelok.elso_ausztriaba_abc}\n");

Console.WriteLine("6. feladat:");
Console.Write($"Magyarországgal szomszédos országok:");
foreach (var item in hataratkelok.ahova_vezet_hataratkelo)
{
    Console.Write($" {item}");
}

Console.WriteLine();
Console.WriteLine($"7. feladat:");
Console.WriteLine($"Kösúti és vasúti határátkelővel is rendelkező városok: ");
foreach (var item in hataratkelok.kozuti_es_vasuti)
{
    Console.Write($" {item},");
}

Console.WriteLine();
Console.WriteLine($"8. feladat:");
foreach (var item in hataratkelok.orszagok_szerint)
{
    Console.WriteLine($"{item.Key} - {item.Value} határátkelő.");
}

Console.WriteLine();
Console.WriteLine($"9. feladat");

Console.WriteLine("Vas: ");
foreach (var item in hataratkelok.megyenkent("Vas"))
{
    Console.WriteLine($"{item.Telepules_nev} - {item.Szomszed_telepules}({item.Oraszag}) - {item.Atkelo_tipus}");

}

Console.WriteLine();


Console.WriteLine("Zala: ");
foreach (var item in hataratkelok.megyenkent("Zala"))
{
    Console.WriteLine($"{item.Telepules_nev} - {item.Szomszed_telepules}({item.Oraszag}) - {item.Atkelo_tipus}");

}

Console.WriteLine();



static IEnumerable<Hataratkelo> Beolvasas()
{
    foreach (var item in File.ReadLines("hataratkelok.csv").Skip(1))
    {
        string[] adatSor = item.Split(';');
        yield return new Hataratkelo(adatSor[0], adatSor[1], adatSor[2], adatSor[3], adatSor[4], adatSor[5]);
    }
}