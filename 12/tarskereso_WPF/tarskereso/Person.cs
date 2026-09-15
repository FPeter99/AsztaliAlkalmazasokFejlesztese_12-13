using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarskereso
{
    public class Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public char Gender { get; set; }

        public Person(string email, string password, char gender)
        {
            Email = email;
            Password = password;
            Gender = gender;
        }
    }
}
