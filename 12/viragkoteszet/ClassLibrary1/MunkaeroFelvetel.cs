using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MunkaeroFelvetel
    {
        public static Dolgozo DolgozoFelvetel(string adatsor) 
        {
            string[] adatok = adatsor.Split(';');
            return adatok[2] switch
            {
                "gy" => new Gyakornok(int.Parse(adatok[0]), adatok[1], adatok.Skip(3).Select(x => int.Parse(x))),
                "v" => new Viragkoto(int.Parse(adatok[0]), adatok[1]),
                _ => throw new ArgumentException("Ismeretlen dolgozo tipus")
            };
        }
    }
}
