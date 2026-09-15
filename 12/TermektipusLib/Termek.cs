using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermektipusLib
{
    public abstract class Termek : ITermek
    {
        public string Nev { get; private set; }
        public int Ar { get; private set; }

        public Termek(string nev, int ar)
        {
            Nev = nev;
            Ar = ar;
        }
    }
}

