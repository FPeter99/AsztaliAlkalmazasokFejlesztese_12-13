using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxKivalasztas;
        private int kivalasztottDb;
        public MainWindow()
        {
            InitializeComponent();
            Jatekmod_kivalasztas(null, null);

            BT_sorsolas.IsEnabled = false;
        }
    

        private void Jatekmod_kivalasztas(object sender, RoutedEventArgs e)
        {
            if (LottoGrid == null) return;

            if (RB_otos.IsChecked == true)
            {
                GenerateGrid(5);
                maxKivalasztas = 5;
            }
            else if (RB_hatos.IsChecked == true)
            {
                GenerateGrid(6);
                maxKivalasztas = 6;
            }
            else if (RB_skandinav.IsChecked == true)
            {
                GenerateGrid(7);
                maxKivalasztas = 7;
            }
            kivalasztottDb = 0;
            GombAllapotFrissites();
            EredmenyDobozUrites();
        }
        private void GenerateGrid(int tipus)
        {
            LottoGrid.Children.Clear();

            int sor = 0;
            int oszlop = 0;

            if (tipus == 5)
            {
                sor = 10;
                oszlop = 9;
            }
            else if (tipus == 6)
            {
                sor = 9;
                oszlop = 5;
            }
            else if (tipus == 7)
            {
                sor = 7;
                oszlop = 5;
            }

            LottoGrid.Rows = sor;
            LottoGrid.Columns = oszlop;

            for (int i = 1; i <= sor * oszlop; i++)
            {
                Button btn = new Button
                {
                    Content = i.ToString(),
                    Background = Brushes.White,
                    BorderBrush = Brushes.White,
                };

                btn.Click += BT_click;


                LottoGrid.Children.Add(btn);
            }
        }
        private void BT_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Background == Brushes.LightGreen)
            {
                btn.Background = Brushes.White;
                kivalasztottDb--;
            }
            else
            {
                if (kivalasztottDb >= maxKivalasztas)
                    return;

                btn.Background = Brushes.LightGreen;
                kivalasztottDb++;
            }

            GombAllapotFrissites();
        }
        private void GombAllapotFrissites()
        {
            BT_sorsolas.IsEnabled = (kivalasztottDb == maxKivalasztas);
        }
        private void Sorsolas_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int max = LottoGrid.Rows * LottoGrid.Columns;
            List<int> sorsolt = new List<int>();


            while (sorsolt.Count < maxKivalasztas)
            {
                int num = rnd.Next(1, max + 1);

                if (!sorsolt.Contains(num))
                    sorsolt.Add(num);
            }

            int talalat = 0;

            foreach (Button b in LottoGrid.Children)
            {
                int kivalasztott = int.Parse(b.Content.ToString());

                if (sorsolt.Contains(kivalasztott))
                {

                    if (b.Background == Brushes.LightGreen)
                        talalat++;
                }
            }

            Eredmeny.Text =
                $"Kihúzott számok: {string.Join(", ", sorsolt)}\n" +
                $"Találatok: {talalat}";
        }
        private void EredmenyDobozUrites() 
        {
            Eredmeny.Text = "";
        }
    }

}