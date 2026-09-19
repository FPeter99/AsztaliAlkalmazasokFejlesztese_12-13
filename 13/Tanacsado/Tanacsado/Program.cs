using ClassLibrary1;

Console.WriteLine($"5. feladat: {DataStore.Instance.tobbMintHaromOra()} találkozó tartott legalább 3 órát");

Console.Write("6. feladat: A tanácsadó neve: ");
string nev = Console.ReadLine()!;

Tanacsado t = DataStore.Instance.NevAlapu(nev);
if (t == null)
{
    Console.WriteLine("Ilyen néven tanácsadó nem található");
}
else
{
    Console.WriteLine($"\tTelefon: {t.telefon}");
    Console.WriteLine($"\tEmail: {t.email}");
    Console.WriteLine($"\tSzakterület: {DataStore.Instance.szakteruletek.FirstOrDefault(x => x.szakteruletId == t.szakteruletId).megnevezes}");
    Console.WriteLine($"\tÓradíj: {t.oradij}");
}


Console.WriteLine("7. feladat: A 3 legtöbbet kereső tanácsadó:");
foreach (Tanacsado top in DataStore.Instance.legtobbetkeresok) 
{
    Console.WriteLine($"\t{top.nev}: {top.oradij*(DataStore.Instance.talalkozok.Count(x=>x.tanacsadoId==top.tanacsadoId))}");
}
