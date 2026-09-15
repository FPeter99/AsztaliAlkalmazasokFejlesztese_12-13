using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public sealed class Diak : Szemely, IVizsgalat
    {
        public int puskakSzama;

        public Diak(string nev, DateOnly szulDatum, int puskakSzama) : base(nev, szulDatum)
        {
            this.puskakSzama = puskakSzama;
        }

        public bool JoAanyE()
        {
            if (puskakSzama == 0) { return true; }
            else { return false; }
        }

        public override string ToString()
        {
            return $"{nev} ({Kor}, {(JoAanyE() ? "Jó" : "Rossz")})";

        }
    }
}
