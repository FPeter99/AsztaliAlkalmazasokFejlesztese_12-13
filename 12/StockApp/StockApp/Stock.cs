using System.Globalization;

namespace StockApp
{
    public class Stock
    {
        public string ticker;
        public string stockName;
        public bool isEtf;
        public double priceInUSD;

        public Stock(string sor) 
        {
            string[] adat = sor.Split(';');
            
            ticker = adat[0];
            stockName = adat[1];
            isEtf = adat[2] == "true";
            priceInUSD = Convert.ToDouble(adat[3], CultureInfo.InvariantCulture);
        }
        
    }
}
