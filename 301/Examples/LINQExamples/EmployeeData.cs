namespace LINQExamples
{
    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public decimal? Salary { get; set; }
        public decimal? HourlyRate { get; set; }
        public int BadgeID { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj is Employee)
            {
                return ((Employee)obj).BadgeID == BadgeID;
            }

            return false;
        }
    }

    public class EmployeeData
    {
        public static List<Employee> Get()
        {
            return new List<Employee>
            {
                new Employee{FirstName="John", LastName="Doe", Title="Manager", Department="HR", 
                    HireDate=new DateTime(2021,5,1), Salary=70000m, BadgeID=101},
                new Employee{FirstName="Jane", LastName="Smith", Title="Developer", Department="IT", 
                    HireDate=new DateTime(2022,1,15), Salary=65000m, BadgeID=102},
                new Employee{FirstName="Michael", LastName="Johnson", Title="Analyst", Department="Finance", 
                    HireDate=new DateTime(2020,6,20), TerminationDate=new DateTime(2023,6,20), Salary=60000m, BadgeID=103},
                new Employee{FirstName="Alice", LastName="Williams", Title="Developer", Department="IT", 
                    HireDate=new DateTime(2019,3,10), Salary=63000m, BadgeID=104},
                new Employee{FirstName="Bob", LastName="Brown", Title="Manager", Department="Sales", 
                    HireDate=new DateTime(2021,8,24), Salary=72000m, BadgeID=105},
                new Employee{FirstName="Carol", LastName="Martinez", Title="Administrator", Department="HR", 
                    HireDate=new DateTime(2022,4,5), Salary=59000m, BadgeID=106},
                new Employee{FirstName="Dave", LastName="Taylor", Title="Support", Department="Ops", 
                    HireDate=new DateTime(2021,11,30), HourlyRate=15.5m, BadgeID=107},
                new Employee{FirstName="Eva", LastName="Gonzalez", Title="Janitorial", Department="Ops", 
                    HireDate=new DateTime(2020,9,15), HourlyRate=17m, BadgeID=108},
                new Employee{FirstName="Frank", LastName="Thomas", Title="Reception", Department="Ops", 
                    HireDate=new DateTime(2021,12,1), HourlyRate=18m, BadgeID=109},
                new Employee{FirstName="Grace", LastName="Lee", Title="Exec Assistant", Department="Ops", 
                    HireDate=new DateTime(2019,7,7), TerminationDate=new DateTime(2020, 1, 27), HourlyRate=20m, BadgeID=110},
            };
        }
    }

}
