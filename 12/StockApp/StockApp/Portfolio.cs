using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Portfolio
    {
        public string ticker;
        public double quantity;

        public Portfolio(string sor) 
        {
            string[] adat = sor.Split(';');

            ticker = adat[0];
            quantity = Convert.ToDouble(adat[1], CultureInfo.InvariantCulture);

        }
    }
}
