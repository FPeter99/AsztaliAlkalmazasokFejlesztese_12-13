using ClassLibrary1;

Dobasok dobasok = new(Beolvasas());



Console.WriteLine("2. feladat");
Console.WriteLine($"Körök száma: {dobasok.Korok_szama}");

Console.WriteLine();

Console.WriteLine("3. feladat");
Console.WriteLine($"3. dobásra Bullseye: {dobasok.D25_harmadikra}");

Console.WriteLine();

Console.WriteLine("4. feladat");
Console.Write("Adja meg a szektort: ");
string szektor = Console.ReadLine();

Console.WriteLine($"Az 1. játákos a(z) {szektor} szektoros dobásainak szába: {dobasok.Szektor_dobasok(szektor, 1)}");
Console.WriteLine($"A 2. játákos a(z) {szektor} szektoros dobásainak szába: {dobasok.Szektor_dobasok(szektor, 2)}");

Console.WriteLine();

Console.WriteLine("5. feladat");
Console.WriteLine($"Az 1. játékos {dobasok.T20(1)} db 180-ast dobott.");
Console.WriteLine($"Az 1. játékos {dobasok.T20(2)} db 180-ast dobott.");



static IEnumerable<Dobas> Beolvasas() 
{
    foreach (var item in File.ReadLines("dobasok.txt")) 
    {
        string[] adatsor = item.Split(';');
        yield return new Dobas(int.Parse(adatsor[0]), adatsor[1], adatsor[2], adatsor[3]);
    }
}