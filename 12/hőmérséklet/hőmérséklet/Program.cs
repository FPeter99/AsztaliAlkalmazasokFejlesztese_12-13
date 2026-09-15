

List<List<int>> matrix = new List<List<int>>();
int N, M;


using (StreamReader sr = new StreamReader("homerseklet.txt"))
{
    string elso = sr.ReadLine();
    N = Convert.ToInt32(elso.Split(' ')[0]);
    M = Convert.ToInt32(elso.Split(' ')[1]);

    for (int i = 0; i < N; i++)
    {
        string sor = sr.ReadLine();
        string[] adatok = sor.Split(' ');
        List<int> sorAdat = new List<int>();
        foreach (string elem in adatok)
        {
            sorAdat.Add(int.Parse(elem));
        }
        matrix.Add(sorAdat);
    }
}


Console.WriteLine("1. feladat:");


// fejléc
Console.Write("".PadLeft(10));
for (int j = 0; j < M; j++)
{
    Console.Write($"{(j + 1)}. mérés".PadLeft(10));
}
Console.WriteLine();

// sorok
for (int i = 0; i < N; i++)
{
    Console.Write($"{i + 1}. nap:".PadRight(12));
    for (int j = 0; j < M; j++)
    {
        Console.Write($"{matrix[i][j]}".PadRight(10));
    }
    Console.WriteLine();
}







// 2.
Console.WriteLine();
Console.Write("2. feladat: ");

double átlag = 0;
foreach (var sor in matrix)
{
    foreach (var elem in sor)
    {
        átlag += elem;
    }
}

Console.WriteLine($"A mérések átlaga: {(Math.Round(átlag / (N * M), 2)):0.00} fok");



// 3.
Console.WriteLine();
Console.WriteLine("3. feladat: Az átlaghőmérséklet naponként:");
for (int i = 0; i < N; i++)
{
    double napiÁtlag = 0;
    foreach (var elem in matrix[i])
    {
        napiÁtlag += elem;
    }
    Console.WriteLine($"\t{i + 1}. nap: {(Math.Round(napiÁtlag / M, 2)):0.00} fok");
}

//4
Console.WriteLine();
int db = 0;
foreach (var sor in matrix) {
    foreach (var elem in sor)
    {
        if (elem < 10)
        {
            db++;
        }
    }
}
Console.WriteLine($"4. feladat: {db} alkalommal volt 10 fok alatt a főmérséklet");

//5
Console.WriteLine();

int dbNap = 0;
foreach (var nap2 in matrix) {
    foreach (var elem in nap2) {
        if (elem < 10) {
            dbNap++;
            break;
        }
    }
}

Console.WriteLine($"5. feladat: {dbNap} nap volt 10 fok alatt a főmérséklet");

//6
Console.WriteLine();

int? nap = null;
int? meres = null;
int max = int.MinValue;
for (int sor = 0; sor < N;sor++)
{
    for (int elem = 0; elem < M; elem++)
    {
        if (elem > max)
        {
            nap = sor + 1;
            meres = elem + 1;
            max = matrix[sor][elem];
        }
    }
}

Console.WriteLine($"6. feladat: {nap}. nap {meres}. mérésekor volt a legmagasabb a hőmérséklet: {max} fok");

//7
Console.WriteLine();
Console.Write("7. feladat: Keresett hőmérséklet érték: ");
int keresett = Convert.ToInt32(Console.ReadLine());
for (int sor = 0; sor < N; sor++)
{
    for (int elem = 0; elem < M; elem++)
    {
        if (matrix[sor][elem] == keresett)
        {
            Console.WriteLine($"\tA keresett érték a(z) {sor + 1}. napon a(z) {elem + 1}. mérése.");
            
        }
    }
}
