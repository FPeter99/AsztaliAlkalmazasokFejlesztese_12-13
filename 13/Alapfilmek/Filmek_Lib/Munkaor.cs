using System;
using System.Collections.Generic;
using System.Text;

namespace Filmek_Lib
{
    public class Munkaor
    {
        public int munkakorazon { get; init; }
        public string munkakor { get; init; }

        public Munkaor(string sor) 
        {
            string[] sorelem = sor.Split('\t');
            munkakorazon = Convert.ToInt32(sorelem[0]);
            munkakor = sorelem[1];
        }
    }
}
