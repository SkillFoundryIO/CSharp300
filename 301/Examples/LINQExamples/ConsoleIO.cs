namespace LINQExamples
{
    public class ConsoleIO
    {
        public static void PrintEmployees(IEnumerable<Employee> employees, string title)
        {
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 123));

            Console.WriteLine($"{"ID",-5}{"FirstName",-15}{"LastName",-15}{"Title",-20}" + 
                $"{"Department",-15}{"HireDate",-15}{"TermDate",-15}{"Salary",-10}{"Hourly",-13}");
            Console.WriteLine(new string('=', 123));

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.BadgeID,-5}{employee.FirstName,-15}{employee.LastName,-15}" +
                    $"{employee.Title,-20}{employee.Department,-15}{employee.HireDate.ToString("yyyy-MM-dd"),-15}" + 
                    $"{(employee.TerminationDate?.ToString("yyyy-MM-dd") ?? "N/A"),-15}" + 
                    $"{employee.Salary?.ToString("C0"),-10}{employee.HourlyRate?.ToString("C2"),-15}");
            }
        }

        public static void PrintEmployee(Employee? employee, string title)
        {
            Console.WriteLine(title);
            if (employee == null)
            {
                Console.WriteLine("No employee.");
                return;
            }

            string divider = new string('=', 25);

            Console.WriteLine(divider);
            Console.WriteLine($"Badge ID: {employee.BadgeID}");
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Title: {employee.Title}");
            Console.WriteLine($"Department: {employee.Department}");
            Console.WriteLine($"Hire Date: {employee.HireDate:yyyy-MM-dd}");
            Console.WriteLine($"Termination Date: {employee.TerminationDate?.ToString("yyyy-MM-dd") ?? "N/A"}");
            Console.WriteLine($"Salary: {employee.Salary?.ToString("C0")}");
            Console.WriteLine($"Hourly Rate: {employee.HourlyRate?.ToString("C2")}");
            Console.WriteLine(divider);
        }
    }
}
