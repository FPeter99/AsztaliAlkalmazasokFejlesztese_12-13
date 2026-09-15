using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nyelviskola_Lib;

namespace NyelviskolaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataStore.InitCSV();
            cb_nyelv.ItemsSource = DataStore.Instance.Nyelvek.Select(x=>x.NyelvNev).ToList();
        }

        private void cb_nyelv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nyelv = cb_nyelv.SelectedItem as string; //alapból mindig object
            int id = DataStore.Instance.Nyelvek.FirstOrDefault(x => x.NyelvNev == nyelv).NyelvID;

            var tanarok = DataStore.Instance.Tanarok.Where(x=>x.NyelvID == id);
            cb_tanar.ItemsSource = tanarok.Select(x=>x.Nev).ToList();

            if (tanarok.Any())
            {
                cb_tanar.IsEnabled = true;
            }else
            {
                cb_tanar.IsEditable=false;
                gr_adatok.Visibility = Visibility.Hidden;
            }
        }

        private void cb_tanar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tanar = DataStore.Instance.Tanarok.FirstOrDefault(x => x.Nev == (cb_tanar.SelectedItem as string));

            if (tanar == null)
            {
                gr_adatok.Visibility = Visibility.Hidden;
                return;
            }
            else 
            {
                tb_telefon.Text = tanar.Telefon;
                tb_email.Text = tanar.Email;
                tb_oradij.Text = tanar.Oradij.ToString();
                chb_onlineOra.IsChecked = tanar.Net;
                gr_adatok.Visibility= Visibility.Visible;
            }
        }
    }
}