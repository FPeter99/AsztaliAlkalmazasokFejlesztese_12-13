using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class FeladatLista
    {
        readonly List<Termek> feladatok;

        public FeladatLista()
        {
            feladatok = new List<Termek>();
        }

        public static FeladatLista operator +(FeladatLista lista, Termek ujFeladat)
        {
            FeladatLista ujLista = new FeladatLista();
            ujLista.feladatok.AddRange(lista.feladatok);
            ujLista.feladatok.Add(ujFeladat);
            return ujLista;
        }

        public IEnumerable<Termek> AktualitasFeladatok => feladatok;


    }
}
