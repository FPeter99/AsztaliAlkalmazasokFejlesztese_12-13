using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    static void Main()
    {
        File.WriteAllText("hibalista.txt", "");

        List<Terem> termek = BeolvasTermek("termek.txt");
        List<Foglalas> foglalasok = BeolvasFoglalasok("foglalasok.txt");

        TeremNyilvantartas nyilvantartas = new TeremNyilvantartas(termek);

        Console.WriteLine("Teremazonosítók:");
        foreach (string id in nyilvantartas.TeremAzonositoi)
            Console.WriteLine(id);

        nyilvantartas.TeremFoglalasok(foglalasok);

        Console.WriteLine("\nFoglalások termenként:");
        foreach (Terem t in nyilvantartas.OsszesTerem)
        {
            Console.WriteLine("\n" + t);
        }

        Console.Write("\nAdd meg a tanár azonosítóját: ");
        string tanar = Console.ReadLine();

        Console.WriteLine($"\nA(z) {tanar} tanár foglalásai:");

        foreach (Terem t in nyilvantartas.OsszesTerem)
        {
            var sajatFoglalasok = t.TeremOrarend
                .ToString()
                .Split('\n')
                .Where(s => s.Contains("Tanár ID: " + tanar));

            foreach (string sor in sajatFoglalasok)
                Console.WriteLine(sor);
        }

        Console.WriteLine("\nProgram vége.");
    }

    static List<Terem> BeolvasTermek(string fajl)
    {
        List<Terem> lista = new List<Terem>();

        foreach (string sor in File.ReadAllLines(fajl))
        {
            string[] m = sor.Split(';');
            string tipus = m[0];
            int id = int.Parse(m[1]);
            int helyek = int.Parse(m[2]);
            if (tipus == "A")
            {
                lista.Add(new AltalanosTerem(id, helyek, new Orarend()));
            }
            else if (tipus == "S")
            {
                int takaritas = int.Parse(m[3]);
                lista.Add(new SpecialisTerem(id, helyek, takaritas, new Orarend()));
            }

        }

        return lista;
    }

    static List<Foglalas> BeolvasFoglalasok(string fajl)
    {
        List<Foglalas> foglalasok = new List<Foglalas>();
        StreamWriter sw = new StreamWriter("hibalista.txt", append: true);

        foreach (string sor in File.ReadAllLines(fajl))
        {
            string[] m = sor.Split(';');

            string terem = m[0];
            DateTime kezdet = DateTime.Parse(m[1]);
            int perc = int.Parse(m[2]);
            string tanar = m[3];

            try
            {
                foglalasok.Add(new Foglalas(terem, kezdet, perc, tanar));
            }
            catch (Exception ex)
            {
                sw.WriteLine(sor + " | Hiba: " + ex.Message);
            }
        }

        sw.Close();
        return foglalasok;
    }
}
