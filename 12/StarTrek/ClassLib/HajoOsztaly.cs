using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class HajoOsztaly
    {
        public int OsztalyID { get; init; }
        public string OsztalyNev { get; init; }
        public int SzerepID { get; init; }

        public HajoOsztaly(string sor) 
        {
            string[] arr = sor.Split(';');
            OsztalyID = Convert.ToInt32(arr[0]);
            OsztalyNev = arr[1];
            SzerepID = Convert.ToInt32(arr[2]);
        }
    }
}
