using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasLib
{
    public class Sutemenyek
    {
        public readonly List<Sutemeny> SutemenyLista;

        public Sutemenyek(IEnumerable<Sutemeny> sutemenyek) 
        {
            SutemenyLista = sutemenyek.ToList();
        }

        public Sutemeny this[string id] 
        {
            get => SutemenyLista.FirstOrDefault(x => x.Azonosito == id)!; 
        }

        public List<Sutemeny> SutemenyTipusok => SutemenyLista.Where(x => x.Tipus[0] != 'd').OrderBy(x => x.Azonosito).ToList();
    }
}
