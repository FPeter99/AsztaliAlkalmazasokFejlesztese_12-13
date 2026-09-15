using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Konyvjelzo
{
    /// <summary>
    /// Interaction logic for Konyvhozzaadas.xaml
    /// </summary>
    public partial class Konyvhozzaadas : Window
    {
        private MainWindow mainWindow;

        public Konyvhozzaadas(MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw;
        }

        public void bt_Mentes(object sender, RoutedEventArgs e)
        {
            string? cim = nevMezo.Text;
            string? szerzo = szerzoMezo.Text;

            if (string.IsNullOrWhiteSpace(cim) || string.IsNullOrWhiteSpace(szerzo))
            {
                MessageBox.Show("A cím és a szerző mezők kitöltése kötelező");
                return;
            }

            ListBoxItem ujElem = new ListBoxItem();
            TextBlock tb = new TextBlock();
            tb.FontSize = 20;
            tb.Text = $"{cim} - {szerzo}";
            ujElem.Content = tb;

            mainWindow.lb_Konyvek.Items.Add(ujElem);

            this.Close();
        }

        public void bt_Megsem(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
