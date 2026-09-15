using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Dolgozo
    {
        protected FeladatLista feladatLista = new FeladatLista();
        public int ID { get; init; }
        public string Nev { get; init; }


        public abstract int Gyakorlottsag { get; }
        public abstract double MunkaraForditottIdo { get; }


        public Dolgozo(int id, string nev)
        {
            ID = id;
            Nev = nev;
        }
        public virtual void UjFeladatHozzaadasa(Termek feladat)
        {
            feladatLista += feladat;
        }



        public override string ToString() 
        {
            return $"{Nev}: {MunkaraForditottIdo} perc";

        }
    }
}
