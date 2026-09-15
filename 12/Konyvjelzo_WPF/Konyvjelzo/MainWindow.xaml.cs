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

namespace Konyvjelzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Konyv> Konyvek = new List<Konyv>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Torles(object sender, RoutedEventArgs e) 
        {
            if (lb_Konyvek.SelectedItem != null)
            {
                lb_Konyvek.Items.Remove(lb_Konyvek.SelectedItem);
            }
            else 
            {
                MessageBox.Show("Nem jelölt ki törlendő elemet");
            }
        }

        public void bt_Hozzaadas(object sender, RoutedEventArgs e)
        {
            Konyvhozzaadas hozzaadasWindow = new Konyvhozzaadas(this);
            hozzaadasWindow.ShowDialog();
        }
    }
}