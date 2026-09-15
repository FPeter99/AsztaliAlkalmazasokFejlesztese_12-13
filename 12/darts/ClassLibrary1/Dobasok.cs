using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Dobasok
    {
        readonly List<Dobas> dobasok;

        public Dobasok(IEnumerable<Dobas> bekapott)
        {
            dobasok = bekapott.ToList();
        }


        public int Korok_szama => dobasok.Count();

        public int D25_harmadikra => dobasok.Count(x=>x.Harmadik == "D25");

        public int Szektor_dobasok(string szektor, int jatekos) => dobasok.Where(x=>x.Szam == jatekos).Count(x => x.Elso == szektor || x.Masodik == szektor || x.Harmadik == szektor);


        public int T20(int jatekos) => dobasok.Where(x => x.Szam == jatekos).Count(x => x.Elso == "T20" && x.Masodik == "T20" && x.Harmadik == "T20");
        //cuccok



    }
}
