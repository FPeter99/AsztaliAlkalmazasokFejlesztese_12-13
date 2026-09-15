using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Currency
    {
        public int currencyId;
        public string currencyCode;
        public string currencyName;
        public double unitPerUSD;

        public Currency(string sor)
        {
            string[] adat = sor.Split(';');

            currencyId = Convert.ToInt32(adat[0]);
            currencyCode = adat[1];
            currencyName = adat[2];
            unitPerUSD = Convert.ToDouble(adat[3], CultureInfo.InvariantCulture); // koszonom a segitseget chatgpt <3

        }
    }
}
