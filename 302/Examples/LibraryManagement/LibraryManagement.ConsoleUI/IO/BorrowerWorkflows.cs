using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces.Services;

namespace LibraryManagement.ConsoleUI.IO
{
    public static class BorrowerWorkflows
    {
        public static void GetAllBorrowers(IBorrowerService service)
        {
            Console.Clear();
            Console.WriteLine("Borrower List");
            Console.WriteLine($"{"ID",-5} {"Name",-32} Email");
            Console.WriteLine(new string('=', 70));
            var result = service.GetAllBorrowers();

            if (result.Ok)
            {

                foreach (var b in result.Data)
                {
                    Console.WriteLine($"{b.BorrowerID,-5} {b.LastName + ", " + b.FirstName,-32} {b.Email}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }

        public static void GetBorrowerById(IBorrowerService service)
        {
            Console.Clear();
            var id = Utilities.GetPositiveInteger("Enter borrower id: ");
            var result = service.GetBorrower(id);

            if(result.Ok)
            {
                Console.WriteLine("\nBorrower Information");
                Console.WriteLine("====================");
                Console.WriteLine($"Id: {result.Data.BorrowerID}");
                Console.WriteLine($"Name: {result.Data.LastName}, {result.Data.FirstName}");
                Console.WriteLine($"Email: {result.Data.Email}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }

        public static void AddBorrower(IBorrowerService service)
        {
            Console.Clear();
            Console.WriteLine("Add New Borrower");
            Console.WriteLine("====================");

            Borrower newBorrower = new Borrower();

            newBorrower.FirstName = Utilities.GetRequiredString("First Name: ");
            newBorrower.LastName = Utilities.GetRequiredString("Last Name: ");
            newBorrower.Email = Utilities.GetRequiredString("Email: ");
            newBorrower.Phone = Utilities.GetRequiredString("Phone: ");

            var result = service.AddBorrower(newBorrower);

            if(result.Ok)
            {
                Console.WriteLine($"Borrower created with id: {newBorrower.BorrowerID}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Utilities.AnyKey();
        }
    }
}
