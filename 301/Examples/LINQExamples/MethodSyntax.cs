namespace LINQExamples
{
    public static class MethodSyntax
    {
        private static IEnumerable<Employee> _employees = EmployeeData.Get();

        public static void WhereExample()
        {
            var activeEmployees = _employees
                .Where(e => e.TerminationDate == null);
            
            ConsoleIO.PrintEmployees(activeEmployees, "Active Employees");
        }

        public static void WhereExample2()
        {
            var everyOtherEmployee = _employees.Where((e, index) => index % 2 == 0);
            
            ConsoleIO.PrintEmployees(everyOtherEmployee, "Every Other Employee");
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

        public static void Contains()
        {
            Console.WriteLine("Does employee with badge id 105 exist?");
            Console.WriteLine(_employees.Contains(new Employee { BadgeID = 105 }));
        }

        public static void Aggregates1()
        {
            var minSalary = _employees.Min(e => e.Salary);
            var maxSalary = _employees.Max(e => e.Salary);
            var avgSalary = _employees.Average(e => e.Salary);
            var sumSalary = _employees.Sum(e => e.Salary);
            var countSalary = _employees.Count(e => e.Salary.HasValue);

            Console.WriteLine($"{minSalary}, {maxSalary}, {avgSalary}, {sumSalary}, {countSalary}");
        }

        public static void Aggregates2()
        {
            int[] nums = { 1, 3, 5, 7, 9 };
            var min = nums.Min();
            var max = nums.Max();
            var avg = nums.Average();
            var sum = nums.Sum();
            var count = nums.Count();

            Console.WriteLine($"{min}, {max}, {avg}, {sum}, {count}");
        }

        public static void First()
        {
            var firstEmployeeInCollection = _employees.First(e => e.Department == "IT");
            ConsoleIO.PrintEmployee(firstEmployeeInCollection, "First Employee in IT");
        }

        public static void First2()
        {
            // this will throw an exception
            var firstEmployeeInCollection = _employees.First(e => e.Department == "Fake");
            ConsoleIO.PrintEmployee(firstEmployeeInCollection, "This will error");
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
            var groupedEmployees = _employees.GroupBy(e => e.Department);

            foreach(var group in groupedEmployees)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach(var employee in group)
                {
                    Console.WriteLine(
                        $"\t{employee.LastName}, {employee.FirstName}");
                }
            }
        }

        public static void SelectCSV()
        {
            var csv = _employees.Select(e => 
                $"{e.BadgeID},{e.LastName},{e.FirstName},{e.Department}");

            foreach(var line in csv)
            {
                Console.WriteLine(line);
            }           
        }

        public static void SelectAnonymous()
        {
            var dropDownList = _employees.Select(e => new
            {
                Text = $"{e.LastName}, {e.FirstName}",
                Value = e.BadgeID
            });

            foreach (var item in dropDownList)
            {
                Console.WriteLine($"{item.Value} - {item.Text}");
            }
        }

        public static void Conversions()
        {
            var list = _employees.Where(e => e.Department == "IT").ToList();
            var array = _employees.Where(e => e.Department == "IT").ToArray();
            var dictionary = _employees.Where(e => e.Department == "IT")
                .ToDictionary(e => e.BadgeID);
        }
    }
}
