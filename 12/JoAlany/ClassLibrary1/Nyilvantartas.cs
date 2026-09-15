using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Nyilvantartas {

        public readonly List<Szemely> szemelyek = new List<Szemely>();

        public Nyilvantartas(IEnumerable<string> file)
        {
            foreach (var sor in file)
            {
                Szemely ujSzemely = new SzemelyFactory().Factory(sor);
                szemelyek.Add(ujSzemely);
            }
        }

        public Szemely this[int i]{
            get => szemelyek[i];
            set => szemelyek[i] = value;
        }

        public IEnumerable<Szemely> szemelyekAdatai => szemelyek;
        

        public IEnumerable<Diak> Diakok => szemelyek.OfType<Diak>();
        public int DiakokSzama => Diakok.Count();

        public IEnumerable<Tanar> Tanarok => szemelyek.OfType<Tanar>();
        public int TanarokSzama => Tanarok.Count();

        public double AtlagTanarEletkor => Tanarok.Average(t => t.Kor);

        public Dictionary<int, int> DiakokSzamaPuskakSzamaSzerint => Diakok.GroupBy(x => x.puskakSzama).ToDictionary(x => x.Key, x => x.Count());
    }
}
