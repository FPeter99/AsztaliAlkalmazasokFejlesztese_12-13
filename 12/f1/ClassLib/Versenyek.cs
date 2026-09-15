using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Versenyek
    {
        public Versenyek(IEnumerable<Verseny> versenyek) {
            this.versenyek = versenyek.ToList();
        }

        readonly List<Verseny> versenyek = new List<Verseny>();



        public List<Verseny> HillPilóták => versenyek
            .Where(x => x.nev.Contains("Hill"))
            .GroupBy(x => x.nev)
            .Select(y => y.First())
            .ToList();

        public List<Verseny> Futamgyőztesek => versenyek
            .Where(x=>x.helyezes == 1)
            .GroupBy(x => x.nev)
            .Select(y => y.First())
            .ToList();

        public int? JuanKor
        {
            get
            {
                var juan = versenyek
                    .Where(x => x.nev == "Juan-Manuel Fangio") // ellenőrizd a helyes név
                    .OrderBy(x => x.datum)
                    .FirstOrDefault();

                if (juan == null || !juan.szuldat.HasValue)
                    return null;

                return juan.datum.Year - juan.szuldat.Value.Year;
            }
        }


        public List<Dictionary<string, int>> ferrari3 => versenyek
            .Where(x => x.tipus == "Ferrari")
            .Where(x => !string.IsNullOrWhiteSpace(x.hiba))
            .GroupBy(x => x.hiba)
            .OrderByDescending(g => g.Count())
            .Take(3)
            .Select(g => new Dictionary<string, int> { { g.Key, g.Count() } })
            .ToList();

        public string NincsCsapat => versenyek
            .Where(x => string.IsNullOrWhiteSpace(x.csapat))
            .GroupBy(x => x.nev)
            .Count()
            .ToString();

        public List<string> OrszagokAzElsoMagyarUtán
        {
            get
            {
                var elsoMagyarDatum = versenyek
                    .Where(v => v.helyszin == "Magyarország")
                    .Select(v => (DateOnly?)v.datum)
                    .Min();

                if (!elsoMagyarDatum.HasValue)
                    return new List<string>();

                return versenyek
                    .Where(x => x.datum > elsoMagyarDatum.Value)
                    .Select(x => x.helyszin)
                    .Distinct()
                    .ToList();
            }
        }

        public void WriteFile(string fileName, string country)
        {
            using var file = new StreamWriter(fileName);

            var monacoFutamok = versenyek
                .Where(x => x.helyszin == country && x.helyezes > 0)
                .GroupBy(x => x.datum.Year)
                .OrderBy(g => g.Key);

            foreach (var ev in monacoFutamok)
            {
                file.WriteLine(ev.Key);

                foreach (var versenyzo in ev.OrderBy(v => v.helyezes).Take(6))
                {
                    file.WriteLine($"\t{versenyzo.helyezes}. {versenyzo.nev} ({versenyzo.csapat} {versenyzo.tipus})");
                }

                file.WriteLine();
            }
        }




    }

}
