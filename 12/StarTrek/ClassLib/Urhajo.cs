using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLib
{
    public class Urhajo
    {
        public int UrhajoID { get; init; }
        public string Azonosito { get; init; }
        public string UrhajoNev { get; init; }
        public int OsztalyID { get; init; }
        public int FajID { get; init; }

        public Urhajo(string sor) 
        {
            string[] arr = sor.Split(';');

            UrhajoID = Convert.ToInt32(arr[0]);
            Azonosito = arr[1];
            UrhajoNev = arr[2];
            OsztalyID = Convert.ToInt32(arr[3]);
            FajID = Convert.ToInt32(arr[4]);

        }

        public override string ToString()
        {
            return UrhajoNev;
        }
    }
}
