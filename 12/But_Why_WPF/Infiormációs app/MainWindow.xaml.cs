using System.Diagnostics;
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

namespace Infiormációs_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Eredeti(object sender, RoutedEventArgs e)
        {
            string videoUrl = "https://www.youtube.com/watch?v=mnTU_hJoByA";

            Process.Start(new ProcessStartInfo
            {
                FileName = videoUrl,
                UseShellExecute = true
            });
        }

    }
}