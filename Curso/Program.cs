using Curso.Entites;
using System.Globalization;
using Curso.Entites.Enums;
using System;

namespace Curso
{
    class program{
        static void Main(string[] args)
        {
            Console.WriteLine("Enter department´s name: ");
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string deptName = Console.ReadLine();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Console.WriteLine(" Enter worker data: ");
            Console.WriteLine("Name: ");
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string name = Console.ReadLine();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Console.Write("Leevel (Junior/ MidLevel/ Senior): ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
#pragma warning restore CS8604 // Possível argumento de referência nula.
            Console.Write("Base salary: ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
            double baseSalary =double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
#pragma warning restore CS8604 // Possível argumento de referência nula.


            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker? ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
            int n = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possível argumento de referência nula.


            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
                DateTime date = DateTime.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possível argumento de referência nula.
                Console.WriteLine("Valur per hour: ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
#pragma warning restore CS8604 // Possível argumento de referência nula.
                Console.Write("Duration (hours): ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
                int hours = int.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possível argumento de referência nula.
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ")

#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string monthAndYear = Console.ReadLine();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            int month = int.Parse(monthAndYear.Substring(0, 2));
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departmant: " + worker.Department.Name);
            Console.WriteLine("Incoe for " + monthAndYear + ": " + worker.Income(year, month));

        }
            
    }
}