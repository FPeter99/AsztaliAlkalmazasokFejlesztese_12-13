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

namespace tarskereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            Register regWindow = new Register();
            regWindow.Show();


            this.Close();
        }

        private void LoginTry(object sender, RoutedEventArgs e)
        {

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;


            var user = App.personlist.PersonList.FirstOrDefault(p => p.Email == email && p.Password == password);

            if (user != null)
            {

                MessageBox.Show($"Sikeres bejelentkezés!\nEmail: {user.Email}\nGender: {user.Gender}");

            }
            else
            {

                MessageBox.Show("Hibás email vagy jelszó!");
            }
        }

    }
}