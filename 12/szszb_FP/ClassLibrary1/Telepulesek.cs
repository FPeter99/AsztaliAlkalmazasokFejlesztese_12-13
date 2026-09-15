using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Telepulesek
    {
        private List<Telepules> telepulesek = new List<Telepules>();

        public Telepulesek(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] rész = fajlSor.Split(";");
                string telepulesNev = rész[0];
                string rang = rész[1];
                string terseg = rész[2];
                int terulet = int.Parse(rész[3]);
                int lakossag = int.Parse(rész[4]);

                telepulesek.Add(new Telepules(telepulesNev, rang, terseg, terulet, lakossag));
            }
        }


        public int TelepulesekDB() => telepulesek.Count();

        public double AtlagTerulet() => telepulesek.Average(x => x.Terulet);

        public List<string> TersegekNevei() => telepulesek.DistinctBy(x => x.Terseg).OrderBy(x => x.Terseg).Select(x => x.Terseg).ToList();
        
        public bool LetezoTerseg(string tersegNev) => telepulesek.Any(x => x.Terseg.ToLower() == tersegNev.ToLower());
        
        public Telepules LegnagyobbTelepules(string tersegNev) => telepulesek.Where(x => x.Terseg.ToLower() == tersegNev.ToLower()).OrderByDescending(x => x.Lakossag).First();
        
        public Dictionary<string, int> TelepulesekSzamaRangonkent() => telepulesek.GroupBy(x => x.Rang).ToDictionary(x => x.Key, x => x.Count());
        
        public Dictionary<string, int> TelepulesekLakossagaRangonkent() => telepulesek.GroupBy(x => x.Rang).ToDictionary(x => x.Key, x => x.Sum(x => x.Lakossag));

    }
}
    

