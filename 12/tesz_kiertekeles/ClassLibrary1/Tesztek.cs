using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Tesztek
    {
        public Tesztek(IEnumerable<Teszt> tesztek)
        {
            this.tesztek = tesztek.ToList();
        }
        readonly List<Teszt> tesztek;




        public int nemIrtaMeg => tesztek.Count(x => x.Nev == null);

        public Teszt? tanulo(string nev) => tesztek.FirstOrDefault(
            x => x.Nev == nev);

        public int elsoFeladat => tesztek.Count(x => x.Elso != null);

        public double elsoAtlag()
        {
            double atlag = 0;
            int db = 0;
            foreach (var item in tesztek)
            {
                if (item.Elso != null)
                {
                    atlag += item.Elso.Value;
                    db++;
                }
            }
            return atlag / db;
        }

        public int elsoUres => tesztek.Count(x => x.Elso == null);


        public void MentesSzazalekCsv(int csoportAzonosito)
        {
            using (var writer = new StreamWriter($"szazalek{csoportAzonosito}.csv"))
            {

                writer.WriteLine("sorszám;név;százalék;eredmény");

                int sorszam = 1;
                foreach (var t in tesztek)
                {
                    if (string.IsNullOrWhiteSpace(t.Nev))
                    {

                        writer.WriteLine($"{sorszam}");
                    }
                    else
                    {

                        int osszPont =
                            (t.Elso ?? 0) +
                            (t.Masodik ?? 0) +
                            (t.Harmadik ?? 0) +
                            (t.Negyedik ?? 0) +
                            (t.Otodik ?? 0);

                        int maxPont = 25;
                        int szazalek = (int)Math.Round((double)osszPont / maxPont * 100);

                        string eredmeny = szazalek >= 40 ? "sikeres" : "sikertelen";

                        writer.WriteLine($"{sorszam};{t.Nev};{szazalek}%;{eredmeny}");
                    }
                    sorszam++;
                }
            }
        }


        public Teszt? this[string nev]
        {
            get
            {
                return tesztek.FirstOrDefault(x => x.Nev == nev);
            }
        }

    }
}
