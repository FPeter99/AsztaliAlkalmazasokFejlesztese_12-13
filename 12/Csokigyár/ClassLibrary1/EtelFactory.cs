using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class EtelFactory
    {
        public IEtel Factory(string adatSor) {
            string[] adat = adatSor.Split(';');
            if (adat[adat.Length] == "ptémium") { 
            return new Premiumcsoki(
                adat[0],
                int.Parse(adat[1]),
                adat[2..^1]
                );
            }
            else
            {
                return new Csoki(
                adat[0],
                adat[1].Split(','),
                int.Parse(adat[2])
                );
            }
        }

    }
}
