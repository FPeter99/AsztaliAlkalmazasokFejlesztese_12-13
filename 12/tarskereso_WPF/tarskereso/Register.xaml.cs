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

namespace tarskereso
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            Login regWindow = new Login();
            regWindow.Show();

            this.Close();
        }

        private void RegisterNewPerson(object sender, RoutedEventArgs e)
        {

            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            // Gender lekérése
            char gender;
            if (MaleCheckBox.IsChecked == true)
                gender = 'M';
            else if (FemaleCheckBox.IsChecked == true)
                gender = 'F';
            else
            {
                MessageBox.Show("Kérlek, válaszd ki a nemed!");
                return;
            }


            Person newPerson = new Person(email, password, gender);
            App.personlist.PersonList.Add(newPerson);


            MessageBox.Show($"          Sikeres regisztráció!     \n\nEmail: {email}\nGender: {gender}");
        }




    }
}
