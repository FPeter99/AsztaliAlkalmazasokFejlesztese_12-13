using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Tanar : Szemely, IVizsgalat
    {
        public double atlag {get; init;}

        public Tanar(string nev, DateOnly szulDatum, double atlag) : base(nev, szulDatum)
        {
            this.atlag = atlag;
        }

        public bool JoAanyE()
        {
            return Kor < 30 && atlag >= 3.5;
        }
        public override string ToString()
        {
            return $"{nev} ({Kor}, {(JoAanyE() ? "Jó" : "Rossz")})";
        }
    }
}
