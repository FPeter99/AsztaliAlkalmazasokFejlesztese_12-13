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
using Cseveges;

namespace CsevegesGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Beszelgetes> beszelgetesek = new List<Beszelgetes>();


        public MainWindow()
        {
            InitializeComponent();

            foreach (var sor in File.ReadLines("csevegesek.txt").Skip(1))
            {
                beszelgetesek.Add(new Beszelgetes(sor));
            }

            CB_Feltoltes();

            FillElement();
        }

        public void CB_Feltoltes() 
        {
            List<string> adok = new List<string>();
            List<string> vevok = new List<string>();

            foreach (var elem in beszelgetesek) 
            {
                adok.Add(elem.kezdemenyezo);
                vevok.Add(elem.fogado);
            }
            adok = adok.Distinct().Order().ToList();
            vevok = vevok.Distinct().Order().ToList();
            /*
            foreach (var nev in adok)
            {
                kezdemenyezo.Items.Add(nev);
            }

            foreach (var nev in vevok)
            {
                fogado.Items.Add(nev);
            }
            */
            cb_kezdemenyezo.ItemsSource = adok;
            cb_fogado.ItemsSource = vevok;

            cb_kezdemenyezo.SelectedIndex = 0;
            cb_fogado.SelectedIndex = 0;
        }
        public void FillElement() 
        {

            List<Beszelgetes> kivalsztottBesz = beszelgetesek.Where(x => x.kezdemenyezo == cb_kezdemenyezo.SelectedItem as string && x.fogado == cb_fogado.SelectedItem as string).ToList();

            lb.Items.Clear();

            if (kivalsztottBesz.Count == 0) 
            {
                lb.Items.Add("Nem történt beszélgetés.");
                return;
            }
            int count = 1;
            foreach (var elem in kivalsztottBesz) 
            {
                lb.Items.Add($"{count}. {elem.kezdet.ToString("yy.MM.dd-hh:mm:ss")} --> {elem.veg.ToString("yy.MM.dd-hh:mm:ss")}");
                
            }

            
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillElement();
        }
    }
}