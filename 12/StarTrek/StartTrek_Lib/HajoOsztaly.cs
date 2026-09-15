using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTrek_Lib
{
    public class HajoOsztaly
    {
        public HajoOsztaly(string fajlSor)
        {
            string[] adatok = fajlSor.Split(";");
            OsztalyId = int.Parse(adatok[0]);
            SzerepId = int.Parse(adatok[2]);
            OsztalyNev = adatok[1];
        }
        //osztaly_id;osztaly_nev;szerep_id
        public int OsztalyId { get; init; }
        public int SzerepId { get; init; }
        public string OsztalyNev { get; init; }
        public override string ToString()
        {
            return OsztalyNev;
        }
    }
}
