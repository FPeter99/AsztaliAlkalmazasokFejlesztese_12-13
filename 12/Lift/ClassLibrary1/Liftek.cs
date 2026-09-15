using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class Liftek
    {
        private readonly List<Lift> liftek;

        public Liftek(List<Lift> liftek)
        {
            this.liftek = liftek;
        }
        public Lift this[int szam]
        {
            get { return liftek[szam-1]; }
        }

    }
}
