using ClassLibrary1;
using System.IO;
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

namespace celeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Ember> emberek = new List<Ember>();


        void Feltoltes()
        {
            foreach (var item in File.ReadAllLines("hires.txt").Skip(1)) 
            {
                emberek.Add(new Ember(item));
            }
        }

        void Nemzetisegek()
        {
            var nemzetisek = emberek.Select(x => x.Nemzetiseg).Distinct().Order();
            cb_Nemzetiség.ItemsSource = nemzetisek;
            cb_Nemzetiség.SelectedIndex = 0;
        }

        void Visszaallitas()
        { 
            tb_Nev.Text = String.Empty;
            cb_Foglalkozas.SelectedIndex = 0;
            cb_Nemzetiség.SelectedIndex = 0;
            ch_Vilaghiru.IsChecked = false;
            rb_Frfi.IsChecked = true;
            rb_No.IsChecked = false;
        }
        public MainWindow()
        {
            InitializeComponent();
            Feltoltes();
            Nemzetisegek();
        }

        private void bt_Rogzit_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Nev.Text == String.Empty)
            {
                MessageBox.Show("Adja meg a híres ember nevét!", "Hiba");
                return;
            }
            string urlapAdat = $"{tb_Nev.Text};{cb_Foglalkozas.Text};{cb_Nemzetiség.Text};{(ch_Vilaghiru.IsChecked==true ? "igen" : "nem")};{(rb_Frfi.IsChecked==true ? "férfi" : "nő")}\n";
            File.AppendAllText("hires.txt", urlapAdat, Encoding.UTF8);
            Visszaallitas();
            emberek.Add(new Ember(urlapAdat.Trim()));
            Nemzetisegek();
        }

        private void bt_Megsem_Click(object sender, RoutedEventArgs e)
        {
            Visszaallitas();
        }
    }
}