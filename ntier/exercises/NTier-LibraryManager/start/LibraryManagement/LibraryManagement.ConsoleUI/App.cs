using LibraryManagement.Application;
using LibraryManagement.ConsoleUI.IO;
using LibraryManagement.Core.Interfaces.Application;

namespace LibraryManagement.ConsoleUI
{
    public class App
    {
        IAppConfiguration _config;
        ServiceFactory _serviceFactory;

        public App()
        {
            _config = new AppConfiguration();
            _serviceFactory = new ServiceFactory(_config);
        }

        public void Run()
        {
            do
            {
                int choice = Menus.MainMenu();

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        BorrowerWorkflows.GetAllBorrowers(_serviceFactory.CreateBorrowerService());
                        break;
                    case 2:
                        BorrowerWorkflows.GetBorrowerById(_serviceFactory.CreateBorrowerService());
                        break;
                    case 3:
                        BorrowerWorkflows.AddBorrower(_serviceFactory.CreateBorrowerService());
                        break;
                }
            } while (true);
        }
    }
}
