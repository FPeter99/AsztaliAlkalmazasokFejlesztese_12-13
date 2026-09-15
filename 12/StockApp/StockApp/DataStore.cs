using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class DataStore
    {
        readonly List<Currency> currencies;
        readonly List<Stock> stocks;
        readonly List<Portfolio> portoflio;

        private DataStore()
        {
            currencies = File.ReadAllLines("data\\currencys.csv").Skip(1).Select(x => new Currency(x)).ToList();
            stocks = File.ReadAllLines("data\\stocks.csv").Skip(1).Select(x => new Stock(x)).ToList();
            portoflio = File.ReadAllLines("data\\portfolio.csv").Skip(1).Select(x => new Portfolio(x)).ToList();
        }

        public static DataStore Instance { get; } = new DataStore();

        public IEnumerable<Currency> Currencies => currencies;
        public IEnumerable<Stock> Stocks => stocks;
        public IEnumerable<Portfolio> Portfolio => portoflio;


        public string Legdragabb => stocks.OrderByDescending(x => x.priceInUSD).First().ticker;

        public double PozitcioMeretUSDben(string t) => portoflio.FirstOrDefault(x=>x.ticker == t).quantity * stocks.FirstOrDefault(x=>x.ticker == t).priceInUSD;

        public bool TickerIsEtf(string t) => stocks.FirstOrDefault(x => x.ticker == t).isEtf;

        public double PozitcioMetetAdottPenznemben(string t, string p) => currencies.FirstOrDefault(x => x.currencyCode == p.ToUpper()).unitPerUSD * PozitcioMeretUSDben(t);

    }
}
