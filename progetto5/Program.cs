using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace progetto5
{
    class Program
    {
        struct Employee
        {
            public string name;
            public double hours;
            public double hourly_wage;
            public double salary;
            public bool bonus;
        }
        
        static List<Employee> employees = new List<Employee>();
        
        [STAThread]
        static void Main()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string fileName = "";

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                } else return;
                

                using (StreamReader sr = new StreamReader(fileName))
                {
                    Console.WriteLine($"\n===== Intestation: {sr.ReadLine()} =====");
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');
                        Employee employee = new Employee();

                        employee.name = dat[0];
                        employee.hours = double.Parse(dat[1]);
                        employee.hourly_wage = double.Parse(dat[2]);

                        employee.salary = employee.hours * employee.hourly_wage;
                        if (employee.hours > 160)
                        {
                            employee.salary += 200;
                            employee.bonus = true;
                        }

                        employees.Add(employee);
                    }
                }

                Console.WriteLine($"Employees with the 200€ bonus:");
                double totalSalary = 0;
                foreach(Employee e in employees)
                {
                    if (e.bonus) Console.WriteLine($"- {e.name}");
                    totalSalary += e.salary;
                }

                Console.WriteLine($"Total salary equals {totalSalary}€");
            
            }
            catch (Exception)
            {
                Console.WriteLine("ERRORE: CONTROLLARE IL CODICE!");
            }
        }
    }
}