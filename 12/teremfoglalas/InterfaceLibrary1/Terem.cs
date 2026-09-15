using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Terem
    {
        public int TeremAzonosito { get; init; }
        public int HelyekSzama { get; init; }
        public Orarend TeremOrarend { get; protected set; } // <-- private -> protected

        public Terem(int teremAzonosito, int helyekSzama, Orarend orarend)
        {
            TeremAzonosito = teremAzonosito;
            HelyekSzama = helyekSzama;
            TeremOrarend = orarend;
        }


        public virtual void IdopontFoglalas(Foglalas f)
        {
        }
    }

}
