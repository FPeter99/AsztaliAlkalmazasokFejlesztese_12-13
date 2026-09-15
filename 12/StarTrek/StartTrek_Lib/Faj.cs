using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTrek_Lib
{
    public class Faj
    {
        //faj_id;faj_nev
        public Faj(string fajlSor)
        {
            string[] adatok = fajlSor.Split(';');
            FajId = int.Parse(adatok[0]);
            FajNev = adatok[1];
        }

        public int FajId { get; init; }
        public string FajNev { get; init; }
        public override string ToString()
        {
            return FajNev;
        }
    }
}
