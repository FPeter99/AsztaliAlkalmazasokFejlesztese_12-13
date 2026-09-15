using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTrek_Lib
{
    public class UrHajo
    {
        //urhajo_id;azonosito;urhajo_nev;osztaly_id;faj_id
        public int UrHajoId { get; init; }
        public string Azonosito { get; init; }
        public string UrHajoNev { get; init; }
        public int OsztalyId { get; init; }
        public int FajId { get; init; }
        public UrHajo(string fajlSor)
        {
            string[] adatok = fajlSor.Split(';');
            UrHajoId = int.Parse(adatok[0]);
            Azonosito = adatok[1];
            UrHajoNev = adatok[2];
            OsztalyId = int.Parse(adatok[3]);
            FajId = int.Parse(adatok[4]);
        }
        public override string ToString()
        {
            return UrHajoNev;
        }
    }
}
