using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public class KeszitesAdatok
    {
        readonly List<KeszitesAdat> keszitesLista;
        public KeszitesAdatok(IEnumerable<KeszitesAdat> sorozat) 
        {
            keszitesLista = sorozat.ToList();
        }
        public KeszitesAdat this[string id]
        {
            get => keszitesLista.FirstOrDefault(x => x.Azonosito == id)!;
        }

        public List<string> ElerhetoKeszitesAzonositok => keszitesLista.
            Select(x => x.Azonosito).
            OrderBy(x=>x).
            ToList();




    }
}
