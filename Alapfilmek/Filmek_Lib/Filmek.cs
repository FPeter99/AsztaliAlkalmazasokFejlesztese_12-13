using System;
using System.Collections.Generic;
using System.Text;

namespace Filmek_Lib
{
    public class Filmek
    {
        public int filmazon { get; init; }
        public string cim { get; init; }
        public string ev { get; init; }
        public string szines { get; init; }
        public string mufaj { get; init; }
        public int hossz { get; init; }

        public Filmek(string sor) 
        {
            string[] sorelem = sor.Split('\t');

            filmazon = Convert.ToInt32(sorelem[0]);
            cim = sorelem[1];
            ev = sorelem[2];
            szines =  sorelem[3];
            mufaj = sorelem[4];
            hossz = Convert.ToInt32(sorelem[5]);

        }
    }
}
