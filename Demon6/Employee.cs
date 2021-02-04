using System;
using System.Collections.Generic;
using System.Text;

namespace Demon6
{
    public class Employee
    {

        private string firstName;
        private string lastName;
        private string role;
        private string department;
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

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Department 
        { 
            get { return department; }
            set { department = value; }
        }

        public string GetAllData()
        {
            return lastName + ", " + firstName + ": " + role + ", " + department;
        }

    }
}
