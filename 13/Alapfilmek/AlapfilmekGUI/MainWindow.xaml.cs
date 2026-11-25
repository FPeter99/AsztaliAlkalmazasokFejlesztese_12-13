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
using Filmek_Lib;

namespace AlapfilmekGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cb_alkoto.ItemsSource = Datastore.Instance.Alkotok.OrderBy(x=>x.nev).ToList();

        }

        private void cb_alkotó_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Alkotok alkoto = cb_alkoto.SelectedItem as Alkotok;
            if (alkoto == null) return;
            int alkotoazon = alkoto.alkotoazon;
            List<int> filmazon = Datastore.Instance.Filmstab.
                Where(x => x.alkotoazon == alkotoazon).Select(x => x.filmazon).ToList();

            cb_film.ItemsSource = Datastore.Instance.Filmek.
                Where(x=>filmazon.Contains(x.filmazon)).OrderBy(x=>x.cim);
            cb_film.IsEnabled = true;
            adatok.Text = "";

        }

        private void cb_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filmek film = cb_film.SelectedItem as Filmek;
            if (film == null) return;

            Alkotok alkoto = cb_alkoto.SelectedItem as Alkotok;
            if (alkoto == null) return;
            int alkotoazon = alkoto.alkotoazon;
            int munkakorazon = Datastore.Instance.Filmstab.
                First(x => x.alkotoazon == alkotoazon && x.filmazon == film.filmazon).munkakorazon;


            adatok.Text = $"Alkotó szerepe a filmben:" +
                $"{Datastore.Instance.Munkakor.First(x=>x.munkakorazon==munkakorazon).munkakor}" +
                $"\n\nFilm bemutatásának éve: {film.ev} ({DateTime.Now.Year - Convert.ToInt32(film.ev)} éve)" +
                $"\nMűfaja: {film.mufaj}" +
                $"\nFilm színe: {film.szines}" +
                $"\nFilm hossza: {film.hossz}";
        }
    }
}