using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvjelzo
{
    internal class Konyv
    {
        internal string Cim;
        internal string Szerzo;

        public Konyv(string Cim, string Szerzo) 
        { 
            this.Cim = Cim;
            this.Szerzo = Szerzo;
        }
    }
}
