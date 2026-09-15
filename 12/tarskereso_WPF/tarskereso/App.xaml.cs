using System.Configuration;
using System.Data;
using System.Windows;

namespace tarskereso
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Persons personlist = new Persons();


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            personlist = new Persons();

        }
    }



}
