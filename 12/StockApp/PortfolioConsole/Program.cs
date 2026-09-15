using StockApp;


Console.WriteLine($"Összesen: {DataStore.Instance.Stocks.Count()} eszközbe történt befektetés");
Console.Write("Kérek egy tickert: ");
string tickerToPrint = Console.ReadLine();
Console.Write("Kérek egy pénznemet: ");
string penznem = Console.ReadLine();

if (DataStore.Instance.Portfolio.FirstOrDefault(x => x.ticker == tickerToPrint) is not null)
{
    Console.WriteLine($"\tA(z) {tickerToPrint} ticker szimbólumú {(DataStore.Instance.TickerIsEtf(tickerToPrint) ? "Etf" : "Részvény")} pozitció {DataStore.Instance.PozitcioMeretUSDben(tickerToPrint)}$-t ér");

    if (DataStore.Instance.Currencies.FirstOrDefault(x => x.currencyCode == penznem.ToUpper()) is not null)
    {
        Console.WriteLine($"\tEz átszámítva {DataStore.Instance.PozitcioMetetAdottPenznemben(tickerToPrint, penznem):F2} {DataStore.Instance.Currencies.First(x => x.currencyCode == penznem.ToUpper()).currencyName}");

        double totalPortfolioErtek = DataStore.Instance.Portfolio.Sum(x => DataStore.Instance.PozitcioMeretUSDben(x.ticker));

        double tickerValue = DataStore.Instance.PozitcioMeretUSDben(tickerToPrint);

        double szazalek = totalPortfolioErtek == 0 ? 0 : (tickerValue / totalPortfolioErtek) * 100; // 0/0

        Console.WriteLine($"\tEz a teljes portfólió {szazalek:F2}%-a (összesen {totalPortfolioErtek:F2}$)");
    }
    else { Console.WriteLine("\tIlyen pénznem nem található!"); }

}
else { Console.WriteLine("Ilyen tickerszimbólum nem található"); }



Console.WriteLine("Befektetések összesítése:");

var grouped = DataStore.Instance.Portfolio.GroupBy(p => DataStore.Instance.TickerIsEtf(p.ticker) ? "ETF" : "Részvény");

foreach (var elem in grouped)
{
    double total = elem.Sum(p => DataStore.Instance.PozitcioMeretUSDben(p.ticker));

    Console.WriteLine($"{elem.Key}-be fektetett: {total:F2}$");
}

