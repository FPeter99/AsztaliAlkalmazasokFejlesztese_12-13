using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Hataratkelok
    {
        readonly List<Hataratkelo> hataratkelok_lista;

        public Hataratkelok(IEnumerable<Hataratkelo> hataratkelok) { 
            this.hataratkelok_lista = hataratkelok.ToList();
        }


        public int sorok_szama => hataratkelok_lista.Count();

        public int vasuti_hataratkelo => hataratkelok_lista.Count(x => x.Atkelo_tipus == "vasúti");

        public IEnumerable<Hataratkelo> megyei_jogu_varos => hataratkelok_lista.Where(x => x.Telepules_tipus == "megyei jogú város");

        public int ausztriaba_vezeto_hataratkelo => hataratkelok_lista.Count(x => (x.Telepules_tipus == "város" || x.Telepules_tipus == "megyei jogú város") && x.Oraszag == "Ausztria");

        public string elso_ausztriaba_abc => hataratkelok_lista.OrderBy(x => x.Telepules_nev).First(x=> x.Oraszag == "Ausztria").Telepules_nev;
    
        public List<string> ahova_vezet_hataratkelo => hataratkelok_lista.Where(x => x.Oraszag != "Magyarország").OrderBy(x => x.Oraszag).Select(x =>x.Oraszag).Distinct().ToList();

        public List<string> kozuti_es_vasuti =>hataratkelok_lista.OrderBy(x => x.Telepules_nev).GroupBy(x => x.Telepules_nev).Where(x => x.DistinctBy(y => y.Atkelo_tipus).Count() >= 2).Select(x => x.Key).ToList();

        public Dictionary<string, int> orszagok_szerint => hataratkelok_lista.GroupBy(x => x.Oraszag).ToDictionary(x => x.Key, x => x.Count());

        public IEnumerable<Hataratkelo> megyenkent(string megye) => hataratkelok_lista.Where(x => x.Megye == megye);
    }
}
