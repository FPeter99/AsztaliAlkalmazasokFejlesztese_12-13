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
using ClassLib;

namespace StarTrekGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb_Szerep.ItemsSource = DataStore.Instance.HajoSzerepek;
        }

        private void cb_Szerep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cb_Szerep (szerepID) -> Datastore.Instance.HajoOsztalyok (szerepID) -> (hajoId) -> urhajok(hajoID)
            grid_Info.Visibility = Visibility.Hidden;
            var jelenlegiSzerep = cb_Szerep.SelectedItem as HajoSzerep;
            if (jelenlegiSzerep == null) return;
            cb_Urhajo.ItemsSource = DataStore.Instance.Urhajok.Where(x=>x.OsztalyID == DataStore.Instance.HajoOsztalyok.FirstOrDefault(y=>y.SzerepID == jelenlegiSzerep.SzerepID)?.OsztalyID);

        }

        private void cb_Urhajo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoGridFeltoltes();
        }

        void InfoGridFeltoltes()
        {
            var kivalasztottHajo = cb_Urhajo.SelectedItem as Urhajo;
            if (kivalasztottHajo == null) return;
            tb_Osztaly.Text = DataStore.Instance.HajoOsztalyok.FirstOrDefault(x => x.OsztalyID == kivalasztottHajo.OsztalyID)?.OsztalyNev;
            tb_Faj.Text = DataStore.Instance.Fajok.FirstOrDefault(x => x.FajID == kivalasztottHajo.FajID)?.FajNev;
            grid_Info.Visibility = Visibility.Visible;
        }
    }
}