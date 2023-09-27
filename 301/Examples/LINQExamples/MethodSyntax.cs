using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    public static class MethodSyntax
    {
        private static IEnumerable<Employee> _employees = EmployeeData.Get();

        public static void WhereExample()
        {
            var activeEmployees = _employees.Where(e => e.TerminationDate == null);
            ConsoleIO.PrintEmployees(activeEmployees, "Active Employees");
        }

        public static void All()
        {
            Console.WriteLine("Are all employees managers?");
            Console.WriteLine(_employees.All(e => e.Title == "Manager"));
        }

        public static void Any()
        {
            Console.WriteLine("Are any employees managers?");
            Console.WriteLine(_employees.Any(e => e.Title == "Manager"));
        }
    }
}
