using System;
using System.Collections.Generic;
using System.Text;

namespace Demon6
{
    public class Person
    {
        private string firstName = "Pippo";
        private string lastName = "Sconosciuto";

        private int age; 

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Contacts Contacts {get; set;}
        public string GetFullName()
        {
            return firstName + " " + lastName;
        }

        public string GetAllInformation()
        {
            return firstName + " " + lastName + ", " + age;
        }

    }
}
