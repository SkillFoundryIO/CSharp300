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

        public static void First()
        {
            var firstEmployeeInCollection = _employees.First(e => e.Department == "IT");
            ConsoleIO.PrintEmployee(firstEmployeeInCollection, "First Employee in IT");
        }

        public static void Last()
        {
            var lastEmployeeInCollection = _employees.Last(e => e.Department == "IT");
            ConsoleIO.PrintEmployee(lastEmployeeInCollection, "Last Employee in IT");
        }

        public static void FirstOrDefault()
        {
            var defaultEmployee = _employees.FirstOrDefault(e => e.Title == "Intern");
            ConsoleIO.PrintEmployee(defaultEmployee, "Default Null, No Interns");
        }
        public static void OrderingAscending()
        {
            var bySalaryDescending = _employees.Where(e => e.HourlyRate.HasValue)
                .OrderBy(e => e.HourlyRate)
                .ThenBy(e => e.LastName);
            ConsoleIO.PrintEmployees(bySalaryDescending, "Hourly Employees By Lowest Rate");
        }

        public static void OrderingDescending()
        {
            var bySalaryDescending = _employees.Where(e => e.Salary.HasValue)
                .OrderByDescending(e => e.Salary)
                .ThenBy(e => e.LastName);
            ConsoleIO.PrintEmployees(bySalaryDescending, "Salaried Employees By Highest Salary");
        }

        public static void SkipTake()
        {
            var skipTake = _employees.Skip(2).Take(3);
            ConsoleIO.PrintEmployees(skipTake, "Employees 103, 104, and 105");
        }

        public static void Grouping()
        {
            var deptEmployees = _employees.GroupBy(e => e.Department);

            foreach(var dept in deptEmployees)
            {
                Console.WriteLine(new string('=', 25));
                Console.WriteLine($"Department: {dept.Key}");
                foreach(var employee in dept)
                {
                    Console.WriteLine($"{employee.LastName}, {employee.FirstName}");
                }
                Console.WriteLine(new string('=', 25));
            }
        }
    }
}
