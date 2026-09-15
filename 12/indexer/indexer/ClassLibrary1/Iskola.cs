using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Iskola
    {
        private readonly List<Diak> diakok = new List<Diak>();
        private List<Tantargy> tantargyak = new List<Tantargy>();
        public Diak this[int id] =>
            diakok.Where(x => x.Id == id).First();
        public Tantargy this[string nev] =>
            tantargyak.Where(x => x.Nev == nev).First();
        public void DiakFelvetel(string nev, int id, Dictionary<Tantargy, List<int>> tantargyak)
        {
            diakok.Add(
                new Diak(
                    nev,
                    id,
                    tantargyak
                    )
                );
        }
        public void TantargyFelvetel(string nev, int kod)
        {
            tantargyak.Add(
                new Tantargy(
                    nev,
                    kod
                    )
                );
        }
    }
}
