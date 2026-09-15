using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Katalogus
    {
        private readonly Dictionary<string, Alapanyag> alapanyagok;

        public Katalogus(IEnumerable<Alapanyag> alapanyagok) 
        {
            this.alapanyagok = alapanyagok.ToDictionary(x=>x.Azonosito);
        }

        public Alapanyag this[string lekerendoAzonosito]  => alapanyagok[lekerendoAzonosito];

    }
}
