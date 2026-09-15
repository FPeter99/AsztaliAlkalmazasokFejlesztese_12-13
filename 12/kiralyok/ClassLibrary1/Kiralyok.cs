using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Kiralyok
    {
        readonly List<Kiraly> kiralyok;

        public Kiralyok(IEnumerable<Kiraly> kiraly)
        {
            this.kiralyok = kiraly.ToList();
        }

        public List<Kiraly> tizen4edik => kiralyok.Where(x => x.mettol >= 1300 && x.mettol <= 1399).ToList();

        string[] magyarHazak = new[] { "Árpád-ház", "Anjou-ház", "Luxemburgi-ház", "Habsburg–Lotaringiai-ház", "Jagielló-ház" };
        public List<Kiraly> magyarKiralyokEgyszer => kiralyok
                                            .Where(k => magyarHazak.Contains(k.uhaz))
                                            .GroupBy(k => k.nev)              
                                            .Select(g => g.First())          
                                            .OrderByDescending(k => k.szul)
                                            .ToList();

        public List<Kiraly> fiatal => kiralyok.Where(x=>x.mettol - x.szul <= 14)
                                        .OrderBy(x => x.mettol -x.szul).ToList();


        public List<Kiraly> hosszú => kiralyok.OrderByDescending(x => x.meddig - x.mettol).Take(10).ToList();
    
    
        public List<Dictionary<string, int>> uhaz => kiralyok.GroupBy(x=> x.uhaz)
                                                    .OrderByDescending(g => g.Count())
                                                    .Select(g => new Dictionary<string, int> { { g.Key,g.Count() } })
                                                    .ToList();

        public List<string> kelott => kiralyok.Where(x=>x.koronazas == null || x.mettol < x.koronazas).Select(x=>x.nev).ToList();

        public List<Kiraly> uralkodokRagadvannyal => kiralyok.Where(x => !string.IsNullOrWhiteSpace(x.ragnev)).OrderByDescending(x => x.szul).ToList();








    }


}
