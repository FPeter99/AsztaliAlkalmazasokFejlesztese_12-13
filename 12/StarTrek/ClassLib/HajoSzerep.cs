using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class HajoSzerep
    {
        public int SzerepID { get; init; }
        public string SzerepNev { get; init; }

        public HajoSzerep(string sor) 
        {
            string[] arr = sor.Split(';');
            SzerepID = Convert.ToInt32(arr[0]);
            SzerepNev = arr[1];
        }

        public override string ToString() 
        {
            return SzerepNev;
        }
    }
}
