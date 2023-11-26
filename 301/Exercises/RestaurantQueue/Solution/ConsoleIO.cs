namespace RestaurantQueue
{
    public static class ConsoleIO
    {
        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static int DisplayMenu()
        {
            int choice;

            Console.Clear();
            do
            {
                Console.WriteLine("---- Main Menu ----");
                Console.WriteLine("1. Add Party");
                Console.WriteLine("2. Call Next Party");
                Console.WriteLine("3. Remove Party");
                Console.WriteLine("4. List All Parties");
                Console.WriteLine("5. View On-Deck Party");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");

                if(int.TryParse(Console.ReadLine(), out choice))
                {
                    if(choice >= 1 && choice <= 6)
                    {
                        return choice;
                    }
                }

                Console.WriteLine("Invalid choice!");
            } while (true);
        }

        public static Party GetPartyInformation()
        {
            Party party = new Party();

            party.LastName = GetLastName();
            party.Count = GetPartyCount();

            return party;
        }

        public static int GetPartyCount()
        {
            int count;

            do
            {
                Console.Write("Enter the number of guests: ");
                if (int.TryParse(Console.ReadLine(), out count))
                {
                    if (count > 0)
                    {
                        return count;
                    }

                    Console.WriteLine("Guest count must be positive!");
                }
            } while (true);
        }

        public static string GetLastName()
        {
            string lastName;

            do
            {
                Console.Write("Enter the last name for the party: ");
                lastName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    return lastName;
                }
            } while (true);
        }

        public static void ListGuests(Queue<Party> partyQueue)
        {
            if (partyQueue.Count == 0)
            {
                Console.WriteLine("The list is empty.\n");
                return;
            }

            foreach (var party in partyQueue)
            {
                Console.WriteLine($"{party.LastName} - Party of {party.Count}");
            }

            Console.WriteLine();
        }

        public static void DisplayParty(Party party)
        {
                Console.WriteLine($"{party.LastName} - Party of {party.Count}\n");
        }
    }
}
