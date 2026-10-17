using HanoiTornyai;

Console.Write("Játék mérete: ");
int meret = Convert.ToInt32(Console.ReadLine());

Hanoi_Logika Jatek = new Hanoi_Logika(meret);

int lepesSzam = 0;

bool nyert = false;
while (!nyert && !Jatek.vesztett)
{
    Console.Clear();
    Console.Write(Jatek);
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine($"Lépésszám: {lepesSzam}");

    Console.Write("Kérem a műveletet (pl: ab -> a-ról átrakni b-re): ");
    string muvelet = Console.ReadLine();

    bool sikeres = Jatek.Mozgatas(muvelet);

    if (sikeres)
    {
        lepesSzam++;
    }

    nyert = Jatek.NyertE();
}

Console.Clear();
Console.Write(Jatek);
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine($"Lépésszám: {lepesSzam}");

if (Jatek.vesztett)
{
    Console.WriteLine("Vesztettél! Egy nagyobb korongot raktál egy kisebbre.");
}
else
{
    Console.WriteLine("Ön nyert!");
}