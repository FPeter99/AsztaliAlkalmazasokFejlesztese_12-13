using System;
using System.Collections.Generic;
using System.Text;

namespace Filmek_Lib
{
    public class Filmstab
    {
        public int filmazon { get; init; }
        public int munkakorazon { get; init; }
        public int alkotoazon { get; init; }

        public Filmstab(string sor) 
        {
            string[] sorelem = sor.Split('\t');
            filmazon = Convert.ToInt32(sorelem[0]);
            munkakorazon = Convert.ToInt32(sorelem[1]);
            alkotoazon = Convert.ToInt32(sorelem[2]);
        }
    }

}
