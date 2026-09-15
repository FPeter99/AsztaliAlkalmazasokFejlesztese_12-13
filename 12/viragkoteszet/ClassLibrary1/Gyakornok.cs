using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Gyakornok : Dolgozo
    {
        readonly List<int> ismertTermekek;
        public Gyakornok(int id, string nev, IEnumerable<int> termekek) : base(id, nev)
        {
            ismertTermekek = termekek.ToList();
        }
        public override int Gyakorlottsag => Random.Shared.Next(7, 10) * 10;

        public override double MunkaraForditottIdo =>
            feladatLista.AktualitasFeladatok.Sum(x => x.ElkeszitesiIdo*((200-Gyakorlottsag)/100));
    
        public void UjFeladatHozzaadasa(Termek feladat)
        {
            if (!ismertTermekek.Contains(feladat.ID))
            {
                throw new HibasFeladatException();
            }
            base.UjFeladatHozzaadasa(feladat);
        }

        public override string ToString()
        {
            return base.ToString() + "(gyakornok)";
        }

    }
}
