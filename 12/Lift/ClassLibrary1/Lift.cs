using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLibrary;

namespace ClassLibrary1
{
    internal class Lift : IMozog
    {

        private int emeletekSzam;
        private int aktualisEmelet;

        public Lift(int emeletekSzam) 
        {
            this.emeletekSzam = emeletekSzam;
            aktualisEmelet = Random.Shared.Next(0, emeletekSzam);
        }


        public void felfele()
        {
            if (aktualisEmelet == emeletekSzam)
            {
                throw new HibasIranyException();
            }

            if (Random.Shared.Next(0, 100) == 100) 
            { 
                throw new Exception("A lift elromlott!");
            }else { aktualisEmelet++; }

        }

        public void lefele()
        {
            if (aktualisEmelet == 0)
            {
                throw new HibasIranyException();
            }

            if (Random.Shared.Next(0, 100) == 100)
            {
                throw new Exception("A lift elromlott!");
            }
            else { aktualisEmelet--; }
        }

        override public string ToString()
        {
            return "";
        }
        
    }
}
