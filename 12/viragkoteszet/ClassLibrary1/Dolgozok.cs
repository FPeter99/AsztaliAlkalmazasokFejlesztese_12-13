using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Dolgozok
    {
        private readonly Dictionary<int, Dolgozo> dolgozok;

        public Dolgozok(IEnumerable<Dolgozo> dolgozok)
        {
            this.dolgozok = dolgozok.ToDictionary(x => x.ID);
        }

        public Dolgozo this[int lekerendoNev] => dolgozok[lekerendoNev];

        public int DolgozokSzama => dolgozok.Count;
    }
}
