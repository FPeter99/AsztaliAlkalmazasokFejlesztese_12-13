using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikulasLib
{
    public class Feladatok
    {
        private readonly List<Feladat> feladatLista;

        public Feladatok()
        {
            feladatLista = new List<Feladat>();
        }

        public Feladatok(IEnumerable<Feladat> feladatok)
        {
            feladatLista = feladatok?.Where(f => f.ElkeszitesiIdo <= 8 * 60).ToList() ?? new List<Feladat>();
        }

        public IEnumerable<Feladat> FeladatLista => feladatLista;

        public static Feladatok operator +(Feladatok feladatok, Feladat feladat)
        {
            feladatok ??= new Feladatok();
            if (feladat != null && feladat.ElkeszitesiIdo <= 8 * 60)
            {
                feladatok.feladatLista.Add(feladat);
            }
            return feladatok;
        }
    }
}
