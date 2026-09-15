using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLib
{
    public class DataStore
    {
        readonly List<Faj> fajok;
        readonly List<HajoOsztaly> hajoOsztalyok;
        readonly List<HajoSzerep> hajoSzerepek;
        readonly List<Urhajo> urhajok;

        private DataStore() 
        {
            fajok = File.ReadAllLines("Input\\fajok.csv").Skip(1).Select(x=>new Faj(x)).ToList();
            hajoOsztalyok = File.ReadAllLines("Input\\hajo_osztalyok.csv").Skip(1).Select(x=> new HajoOsztaly(x)).ToList();
            hajoSzerepek = File.ReadAllLines("Input\\hajo_szerepek.csv").Skip(1).Select(x=>new HajoSzerep(x)).ToList();
            urhajok = File.ReadAllLines("Input\\urhajok.csv").Skip(1).Select(x=>new Urhajo(x)).ToList();
        }

        public static DataStore Instance { get; } = new DataStore();

        public IEnumerable<Faj> Fajok => fajok;
        public IEnumerable<HajoOsztaly> HajoOsztalyok => hajoOsztalyok;
        public IEnumerable<HajoSzerep> HajoSzerepek => hajoSzerepek;
        public IEnumerable<Urhajo> Urhajok => urhajok;

        public void ExportToJson() 
        {
            File.WriteAllText("fajok.json", JsonSerializer.Serialize(fajok, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
