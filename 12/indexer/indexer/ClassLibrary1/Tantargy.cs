using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Tantargy
    {
        public Tantargy(string nev, int kod)
        {
            Nev = nev;
            Kod = kod;
        }
        public string Nev { get; init; }
        public int Kod { get; init; }
    }
}
