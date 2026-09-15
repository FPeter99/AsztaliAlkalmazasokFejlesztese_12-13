using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTrek_Lib
{
    public class HajoSzerep
    {
        //szerep_id;szerep_nev
        public int SzerepId { get; init; }
        public string SzerepNev { get; init; }
        public HajoSzerep(string fajlSor)
        {
            string[] adatok = fajlSor.Split(';');    
            SzerepId = int.Parse(adatok[0]);
            SzerepNev = adatok[1];
        }
        public override string ToString()
        {
            return SzerepNev;
        }
    }
}
