using RestaurantQueue;

PartyManager manager = new PartyManager();
while (true)
{
    int choice = ConsoleIO.DisplayMenu();
    Console.Clear();

    switch (choice)
    {
        case 1:
            Console.WriteLine("---- Add Party ----");

            Party newParty = ConsoleIO.GetPartyInformation();
            manager.AddParty(newParty);

            Console.WriteLine("Party added successfully!\n");
            ConsoleIO.AnyKey();
            break;

        case 2:
            Console.WriteLine("---- Call Party ----");

            Party calledParty = manager.CallParty();
            
            if (calledParty != null)
            {
                Console.WriteLine($"Calling {calledParty.LastName} - Party of {calledParty.Count}");
            }
            else
            {
                Console.WriteLine("There are no parties in the queue.");
            }
            
            ConsoleIO.AnyKey();
            break;

        case 3:
            Console.WriteLine("---- Remove Party ----");

            string lastName = ConsoleIO.GetLastName();
            bool found = manager.RemoveParty(lastName);

            if(found)
            {
                Console.WriteLine("Party removed successfully!\n");
            }
            else
            {
                Console.WriteLine("That name was not on the list!");
            }

            ConsoleIO.AnyKey();
            break;

        case 4:
            Console.WriteLine("---- List All Parties ----");
            
            manager.ListParties();

            ConsoleIO.AnyKey();
            break;

        case 5:
            Console.WriteLine("---- View On-Deck Party ----");

            Party onDeckParty = manager.OnDeckParty();
            if (onDeckParty != null)
            {
                ConsoleIO.DisplayParty(onDeckParty);
            }
            else
            {
                Console.WriteLine("There are no parties in the queue!");
            }
            ConsoleIO.AnyKey();
            break;

        case 6:
            Console.WriteLine("Thank you for using the Restaurant Party Check-In Manager. Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.\n");
            break;
    }
}
