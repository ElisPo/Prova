using System;

namespace Demon6
{
    class Program
    {
        static void Main(string[] args)
        {
            Person persona = new Person();

            persona.Age = 30;
            persona.FirstName = "Matilde";
            persona.LastName = "Pluto";
            Console.WriteLine(persona.GetFullName());

            Person[] persone = new Person[5];
            Random random = new Random();

            for (int i = 0; i < persone.Length; i++)
            {
                persone[i] = new Person()
                {
                    FirstName = String.Format("Pippo{0}", i + 1),
                    LastName = String.Format("Cognome" + 2 * (i + 1)),
                    Age = random.Next(0, 100)
                };

                Console.WriteLine(persone[i].GetAllInformation());
            }

            persona.Contacts = new Contacts
            {
                PhoneNumber = 123,
                Email = "blabla@cose.it",
                Address = new Address
                {
                    City = "Milano",
                    State = "Italy",
                    ZipCode = "20100"
                }
            };

            Console.WriteLine(persona.GetAllInformation() + persona.Contacts.Address.City);

            Employee marco = new Employee() 
            {
                FirstName = "Marco",
                LastName = "Rossi",
                Role = "Developer",
                Department = "IT"
            };

            Console.WriteLine(marco.GetAllData());

            Employee[] employees = EmployeeManagement.GetAllEmployees();

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.LastName + ", " + employee.FirstName + ": " + employee.Role + ", " + employee.Department);
            }

            //Console.WriteLine("Che nome devo cercare nel mio vasto database di 5 nomi? di cui 4 si chiamano Chiara?");
            //string nome = Console.ReadLine();
            //Employee[] employeesTrue = EmployeeManagement.SearchEmployeeName(nome,employees);

            //foreach (Employee employee in employeesTrue)
            //{
              //  Console.WriteLine(employee.LastName + ", " + employee.FirstName + ": " + employee.Role + ", " + employee.Department);
            //}

            EmployeeManagement.AddEmployee(marco);

            bool fatto = EmployeeManagement.DeleteEmployee(marco);
            if (fatto)
            {
                Console.WriteLine("Cancellato!");
            }
        }
    }
}
