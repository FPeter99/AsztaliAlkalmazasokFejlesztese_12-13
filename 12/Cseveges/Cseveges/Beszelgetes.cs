using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    public class Beszelgetes
    {
        /*
         Kezdet;Vég;Kezdeményező;Fogadó
         */
        public DateTime kezdet { get; set; }
        public DateTime veg { get; set; }
        public string kezdemenyezo { get; set; }
        public string fogado { get; set; }

        public Beszelgetes(string sor) 
        {
            string[] elemek = sor.Split(';');

            //21.09.27-15:00:37
            kezdet = DateTime.ParseExact(elemek[0], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            veg = DateTime.ParseExact(elemek[1], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            kezdemenyezo = elemek[2];
            fogado = elemek[3];
        }


    }
}
