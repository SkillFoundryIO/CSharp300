using Hashing;

var passwordManager = new PasswordManager();
passwordManager.Load();

while (true)
{
    Console.Clear();

    Console.WriteLine("Password Manager\n");
    Console.WriteLine("1. Create");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit\n");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "3":
            return;

        case "1":
            var email = ConsoleIO.GetRequiredString("Enter email: ");
            var password = ConsoleIO.GetRequiredString("Enter password: ");

            if (email != null && password != null)
            {
                passwordManager.CreateUser(email, password);
                Console.WriteLine("User created successfully!");
            }

            break;

        case "2":
            var loginEmail = ConsoleIO.GetRequiredString("Enter email: ");
            var loginPassword = ConsoleIO.GetRequiredString("Enter password: ");

            if (loginEmail != null && loginPassword != null)
            {
                if(passwordManager.VerifyPassword(loginEmail, loginPassword))
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid credentials!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            break;
    }
}