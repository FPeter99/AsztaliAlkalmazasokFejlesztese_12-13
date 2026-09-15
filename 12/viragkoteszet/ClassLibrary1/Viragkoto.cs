using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Viragkoto : Dolgozo
    {
        public Viragkoto(int id, string nev) : base(id, nev)
        {
        }

        public override int Gyakorlottsag => 100;

        public override double MunkaraForditottIdo =>
            feladatLista.AktualitasFeladatok.Sum(x =>x.ElkeszitesiIdo);
    }
}
