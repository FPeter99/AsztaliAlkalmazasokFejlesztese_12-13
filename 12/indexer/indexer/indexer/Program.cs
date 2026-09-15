using ClassLibrary1;

Iskola iskola = new Iskola();


iskola.TantargyFelvetel("Magyar", 1);
iskola.TantargyFelvetel("Történelem", 2);
iskola.TantargyFelvetel("Matek", 3);


var petiJegyek = new Dictionary<Tantargy, List<int>>
{
    [iskola["Magyar"]] = new List<int> { 4, 5, 5 },
    [iskola["Matek"]] = new List<int> { 3, 4 }
};

var annaJegyek = new Dictionary<Tantargy, List<int>>
{
    [iskola["Történelem"]] = new List<int> { 2, 3, 3 }
};


iskola.DiakFelvetel("Peti", 1, petiJegyek);
iskola.DiakFelvetel("Anna", 2, annaJegyek);

Console.WriteLine("----- Diákok -----");
Console.WriteLine($"\t{iskola[1].Nev} (ID: {iskola[1].Id})");
Console.WriteLine($"\t{iskola[2].Nev} (ID: {iskola[2].Id})");


iskola[1].JegyFelvetel(iskola["Matek"], new List<int> { 5, 5 });
Console.WriteLine("Peti új matek jegyei: " +
    string.Join(", ", petiJegyek[iskola["Matek"]]));

iskola[2].JegyFelvetel(iskola["Történelem"], new List<int> { 4, 4, 5 });
Console.WriteLine("Anna új történelem jegyei: " +
    string.Join(", ", annaJegyek[iskola["Történelem"]]));


try
{
    var hianyzoDiak = iskola[99];
}
catch (InvalidOperationException)
{
    Console.WriteLine("Nincs ilyen diák az adott azonosítóval!");
}


try
{
    var hianyzoTantargy = iskola["Földrajz"];
}
catch (InvalidOperationException)
{
    Console.WriteLine("Nincs ilyen tantárgy az adott névvel!");
}
