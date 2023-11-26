namespace LINQExamples
{
    public class QuerySyntax
    {
        private static IEnumerable<Employee> _employees = EmployeeData.Get();

        public static void WhereExample()
        {
            var active = from e in _employees
                         where e.TerminationDate == null
                         select e;

            ConsoleIO.PrintEmployees(active, "Active Employees");
        }

        public static void OrderByExample()
        {
            var topSalaries = from e in _employees
                              where e.Salary.HasValue
                              orderby e.Salary descending, e.LastName
                              select e;

            ConsoleIO.PrintEmployees(topSalaries, "Highest salary employees");
        }

        public static void SingleValueExample()
        {
            var lowestPaid = (from e in _employees
                              where e.HourlyRate.HasValue
                              orderby e.HourlyRate
                              select e).First();

            ConsoleIO.PrintEmployee(lowestPaid, "Lowest paid employee");
        }

        public static void Grouping()
        {
            var departmentGroups = from e in _employees
                                   group e by e.Department;

            foreach (var group in departmentGroups)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var employee in group)
                {
                    Console.WriteLine(
                        $"\t{employee.LastName}, {employee.FirstName}");
                }
            }
        }

        public static void SelectCSV()
        {
            var csv = from e in _employees
                      select new string($"{e.BadgeID},{e.LastName},{e.FirstName},{e.Department}");

            foreach (var line in csv)
            {
                Console.WriteLine(line);
            }
        }

        public static void SelectAnonymous()
        {
            var dropDownList = from e in _employees
                               select new
                               {
                                   Text = $"{e.LastName}, {e.FirstName}",
                                   Value = e.BadgeID
                               };

            foreach (var item in dropDownList)
            {
                Console.WriteLine($"{item.Value} - {item.Text}");
            }
        }
    }
}
