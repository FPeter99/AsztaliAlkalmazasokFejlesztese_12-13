using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTrek_Lib
{
    public class AdatBazis
    {
        private readonly List<Faj> fajok;
        private readonly List<HajoOsztaly> hajoOsztalyok;
        private readonly List<HajoSzerep> hajoSzerepek;
        private readonly List<UrHajo> urHajok;

        private AdatBazis()
        {
            fajok = File.ReadAllLines("Fajlok\\fajok.csv").Skip(1)
                .Select(x => new Faj(x)).ToList();
            hajoOsztalyok = File.ReadAllLines("Fajlok\\hajo_osztalyok.csv").Skip(1)
                .Select(x => new HajoOsztaly(x)).ToList();
            hajoSzerepek = File.ReadAllLines("Fajlok\\hajo_szerepek.csv").Skip(1)
                .Select(x => new HajoSzerep(x)).ToList();
            urHajok = File.ReadAllLines("Fajlok\\urhajok.csv").Skip(1)
                .Select(x => new UrHajo(x)).ToList();
        }
        public static AdatBazis? Adatok {  get; private set; }
        public static void Inicializalas()
        {
            if (Adatok is not null)
                throw new InvalidOperationException("Már inicializálva lett az adatbázis!");
            Adatok = new AdatBazis();
        }
        public IEnumerable<UrHajo> UrHajok => urHajok;
        public IEnumerable<HajoOsztaly> HajoOsztalyok => hajoOsztalyok;
        public IEnumerable<HajoSzerep> HajoSzerepek => hajoSzerepek;
        public IEnumerable<Faj> Fajok => fajok;
        public IEnumerable<UrHajo> UrhajokMelybenSzerepel(string nev) =>
            urHajok.Where(uh => uh.UrHajoNev.Contains(nev));
        public int HajoOsztalyokSzamaSzerepAlapjan(string szNev) =>
            hajoOsztalyok.Count(ho=>hajoSzerepek.Find(hsz=>hsz.SzerepId==ho.SzerepId)?.ToString()==szNev);
        public IEnumerable<(string osztalyNev, int urhajokSzama)> AzonosOsztalybanLevoUrhajokOsztalyaEsSzama =>
            urHajok.GroupBy(uh => uh.OsztalyId).Select(uh=>(HajoOsztalyok.FirstOrDefault(ho=>ho.OsztalyId==uh.Key)!.OsztalyNev, uh.Count())).OrderByDescending(x=>x.Item2);
    }
}
