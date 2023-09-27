namespace LINQExamples
{
    public class ConsoleIO
    {
        public static void PrintEmployees(IEnumerable<Employee> employees, string header)
        {
            Console.WriteLine($"{"BadgeID",-10}{"FirstName",-15}{"LastName",-15}{"Title",-20}" + 
                $"{"Department",-15}{"HireDate",-15}{"TermDate",-15}{"Salary",-10}{"Hourly",-15}");
            Console.WriteLine(new string('-', 140));

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.BadgeID,-10}{employee.FirstName,-15}{employee.LastName,-15}" +
                    $"{employee.Title,-20}{employee.Department,-15}{employee.HireDate.ToString("yyyy-MM-dd"),-15}" + 
                    $"{(employee.TerminationDate?.ToString("yyyy-MM-dd") ?? "N/A"),-15}" + 
                    $"{employee.Salary?.ToString("C0"),-10}{employee.HourlyRate?.ToString("C2"),-15}");
            }
        }
    }
}
