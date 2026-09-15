using StockApp;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StockWindow
{
    public partial class MainWindow : Window
    {
        private string selectedTicker = "";
        private string selectedCurrency = "USD";

        public MainWindow()
        {
            InitializeComponent();

            CB_fajta.ItemsSource = new List<string> { "reszveny", "etf" };

            CB_penznem.ItemsSource = DataStore.Instance.Currencies.Select(x => x.currencyCode).OrderBy(x => x).ToList();

            CB_penznem.SelectedItem = "USD";
        }

        private void CB_fajta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_fajta.SelectedItem == null) { return; }

            string tipus = CB_fajta.SelectedItem.ToString();

            if (tipus == "etf") { CB_ticker.ItemsSource = DataStore.Instance.Stocks.Where(x =>x.isEtf).Select(x => x.ticker).OrderBy(x => x).ToList(); }
            else { CB_ticker.ItemsSource = DataStore.Instance.Stocks.Where(x =>!x.isEtf).Select(x => x.ticker).OrderBy(x => x).ToList(); }

            CB_ticker.IsEnabled = true;

            CB_ticker.SelectedItem = null;

            txtInfo.Text = "";
            GB_reszletek.Visibility = Visibility.Hidden;
        }

        private void CB_ticker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_ticker.SelectedItem == null) { return; }

            selectedTicker = CB_ticker.SelectedItem.ToString();

            UpdateDisplay();
        }

        private void CB_penznem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_penznem.SelectedItem == null) {  return; }

            selectedCurrency = CB_penznem.SelectedItem.ToString();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (string.IsNullOrWhiteSpace(selectedTicker)) {  return; }

            var stock = DataStore.Instance.Stocks.FirstOrDefault(x => x.ticker == selectedTicker);

            var portfolioResze = DataStore.Instance.Portfolio.FirstOrDefault(x => x.ticker == selectedTicker);

            if (stock == null || portfolioResze == null) {  return; }

            GB_reszletek.Visibility = Visibility.Visible;

            double convertedValue = DataStore.Instance.PozitcioMetetAdottPenznemben(selectedTicker,selectedCurrency);

                txtInfo.Text =
                    $"Ticker: {selectedTicker}\n\n" +
                    $"Név: {stock.stockName}\n" +
                    $"Típus: {(stock.isEtf ? "ETF" : "Részvény")}\n" +
                    $"Darabszám: {portfolioResze.quantity:F3}\n" +
                    $"Pozíció értéke: {convertedValue:F2} {selectedCurrency}";

        }
    }
}