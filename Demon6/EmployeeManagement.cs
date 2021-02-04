using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demon6
{
    public class EmployeeManagement
    {
        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Corso\Week2\1_02\Demon5\Employees.csv");
        
        public static Employee[] GetAllEmployees()
        {
            int totalLines = File.ReadLines(path).Count();
            Employee[] employees = new Employee[totalLines - 1];
            string line;

            using (StreamReader reader = File.OpenText(path))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    for (int i = 0; i < totalLines -1; i++)
                    {
                        line = reader.ReadLine();
                        string[] employeeData = line.Split(",");
                        Employee employee = new Employee
                        {
                            FirstName = employeeData[0],
                            LastName = employeeData[1],
                            Role = employeeData[2],
                            Department = employeeData[3]
                        };

                        employees[i] = employee;
                    }
                }
            }

            return employees;
        }

        public static Employee[] SearchEmployeeName(string name, Employee[] employees)
        {
            int numberOfNames = 0;
            for (int i = 0; i< employees.Length; i++)
            {
                if (employees[i].FirstName == name)
                    numberOfNames++;
            }
            
            Employee[] employeeTrue = new Employee[numberOfNames];
            int index = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].FirstName == name)
                {
                    employeeTrue[index] = employees[i];
                    index++;
                }
            }

            return employeeTrue;
        }

        public static bool AddEmployee(Employee newEmployee)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamWriter file = File.AppendText(path))
                    {
                        file.WriteLine(newEmployee.FirstName + "," + newEmployee.LastName + "," + newEmployee.Role + "," + newEmployee.Department);
                    }

                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteEmployee(Employee employeeToDelete)
        {
            if (File.Exists(path))
            {
                try 
                {
                    Employee[] allEmployees = GetAllEmployees();

                    int line = 0;
                    ArrayList linesToDelete = new ArrayList { };

                    foreach (Employee em in allEmployees)
                    {
                        if (em.FirstName == employeeToDelete.FirstName && em.LastName == employeeToDelete.LastName && em.Role == employeeToDelete.Role)
                        {
                            linesToDelete.Add(line);
                        }
                        line++;
                    }

                    int[] linesToDeleteInt = (int[])linesToDelete.ToArray(typeof(int));
                    bool flag = false;

                    using (StreamWriter file = File.CreateText(path))
                    {
                        file.WriteLine("firstName,lastName,role,department");

                        for (int i = 0; i < allEmployees.Length; i++)
                        {
                            flag = false;

                            for (int j = 0; j < linesToDelete.Count; j++)
                            {
                                if (i == linesToDeleteInt[j])
                                {
                                    flag = true;
                                }
                            }

                            if (flag)
                                continue;
                            else
                                file.WriteLine(allEmployees[i].FirstName + "," + allEmployees[i].LastName + "," + allEmployees[i].Role + "," + allEmployees[i].Department);

                        }

                    }

                    return true;

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
                return false;
        }
    }
}
