using Encryption;

// Use a simple key for demonstration - in production, use a secure key!
var encryptionService = new EncryptionService("MySecretKey123!");

while (true)
{
    Console.Clear();

    Console.WriteLine("1. Encrypt Text");
    Console.WriteLine("2. Decrypt Text");
    Console.WriteLine("3. Exit\n");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter text to encrypt: ");
            string? plainText = Console.ReadLine();
            if (plainText != null)
            {
                string encrypted = encryptionService.Encrypt(plainText);
                Console.WriteLine($"Encrypted: {encrypted}");
            }
            break;

        case "2":
            Console.Write("Enter text to decrypt: ");
            string? cipherText = Console.ReadLine();

            if (cipherText != null)
            {
                try
                {
                    string decrypted = encryptionService.Decrypt(cipherText);
                    Console.WriteLine($"Decrypted: {decrypted}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid encrypted text!");
                }
            }
            break;

        case "3":
            return;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}