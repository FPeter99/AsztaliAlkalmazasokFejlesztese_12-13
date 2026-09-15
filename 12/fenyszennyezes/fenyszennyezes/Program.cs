// 1.
List<List<int>> A = new List<List<int>>();
int N, M;

using (StreamReader sr = new StreamReader("terkep.txt"))
{
    string[] elso = sr.ReadLine().Split(' ');
    N = Convert.ToInt32(elso[0]);
    M = Convert.ToInt32(elso[1]);

    for (int i = 0; i < N; i++)
    {
        string sor = sr.ReadLine();
        string[] adatok = sor.Split('\t');
        List<int> sorAdat = new List<int>();
        foreach (string elem in adatok)
        {
            sorAdat.Add(int.Parse(elem));
        }
        A.Add(sorAdat);
    }
}


// 2.



Terkep terekp = new Terkep(A); 


Console.WriteLine();
Console.WriteLine("2. feladat");
Console.Write("A mérés sorának azonosítoja: ");
int sor1 = int.Parse(Console.ReadLine());
Console.Write("A mérés oszlopának azonosítoja: ");
int oszlop1 = int.Parse(Console.ReadLine());
Console.WriteLine($"Az adott helyen {terekp[sor1, oszlop1]} a mért fényesség értéke.");

// 3
Console.WriteLine();
Console.WriteLine("3. feladat");
int Sotet = 0;
foreach (var sor in A)
    foreach (var elem in sor)
        if (elem == 0) Sotet++;
double szazalek = 100.0 * Sotet / (N * M);
Console.WriteLine($"A terület {szazalek:F1} %-a teljesen sötét.");

// 4
Console.WriteLine();
Console.WriteLine("4. feladat");
int maxe = A.SelectMany(x => x).Max();
Console.WriteLine($"A legnagyobb fényességértek: {maxe}");
Console.WriteLine("A legfényesebb helyek koordinátái:");
for (int i = 0; i < N; i++)
    for (int j = 0; j < M; j++)
        if (A[i][j] == maxe)
            Console.WriteLine($"({i + 1}, {j + 1})");

// 5
Console.WriteLine();
Console.WriteLine("5. feladat");

int fenyesPontok = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        int ertek = A[i][j];
        bool fenyes = true;


        if (j > 0 && A[i][j - 1] >= ertek) fenyes = false;
        if (j < M - 1 && A[i][j + 1] >= ertek) fenyes = false;
        if (i > 0 && A[i - 1][j] >= ertek) fenyes = false;
        if (i < N - 1 && A[i + 1][j] >= ertek) fenyes = false;

        if (fenyes) fenyesPontok++;
    }
}

Console.WriteLine($"A fényes területek száma: {fenyesPontok} db.");



// 6
Console.WriteLine();
Console.WriteLine("6. feladat");

int minSor = N, maxSor = -1, minOszlop = M, maxOszlop = -1;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < M; j++)
    {
        int ertek = A[i][j];
        bool fenyes = true;

        if (j > 0 && A[i][j - 1] >= ertek) fenyes = false;
        if (j < M - 1 && A[i][j + 1] >= ertek) fenyes = false;
        if (i > 0 && A[i - 1][j] >= ertek) fenyes = false;
        if (i < N - 1 && A[i + 1][j] >= ertek) fenyes = false;

        if (fenyes)
        {
            if (i < minSor) minSor = i;
            if (i > maxSor) maxSor = i;
            if (j < minOszlop) minOszlop = j;
            if (j > maxOszlop) maxOszlop = j;
        }
    }
}



// 7
Console.WriteLine();
Console.WriteLine("7. feladat");
Console.Write("A vizsgált oszlop sorszáma: ");
int col = int.Parse(Console.ReadLine()) - 1;

using (StreamWriter ki = new StreamWriter("diagram.txt"))
{
    for (int i = 0; i < N; i++)
    {
        int ertek = (int)Math.Round(A[i][col] / 10.0) * 10;
        int csillagok = ertek / 10;
        ki.WriteLine(new string('*', csillagok));
    }
}





class Terkep
{
    public List<List<int>> matrix;

    public Terkep(List<List<int>> adat)
    {
        matrix = adat;
    }

    public int this[int sor, int oszlop] 
    {
        get
        {
            return matrix[sor-1][oszlop-1];
        }
    }
}