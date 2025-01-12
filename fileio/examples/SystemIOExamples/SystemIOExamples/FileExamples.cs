namespace SystemIOExamples
{
    public class FileExamples
    {
        // Linux and Mac use / for directories and windows uses \, Path.Combine normalizes this.
        private static string PATH = Path.Combine("Data", "IceCreamFlavors.txt");

        /// <summary>
        /// Demonstrates ReadAllLines() and Exists()
        /// </summary>
        public static void IceCreamReadAllLines()
        {           
            if (File.Exists(PATH))
            {
                string[] flavors = File.ReadAllLines(PATH);
                Console.WriteLine("Ice Cream Flavors:");
                foreach (var flavor in flavors)
                {
                    Console.WriteLine(flavor);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        /// <summary>
        /// Read the file contents as one string
        /// </summary>
        public static void IceCreamReadAllText()
        {
            if (File.Exists(PATH))
            {
                string flavors = File.ReadAllText(PATH);
                Console.WriteLine("Ice Cream Flavors:");
                Console.WriteLine(flavors);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        /// <summary>
        /// Demonstrates a StreamReader()
        /// </summary>
        public static void IceCreamStreamReader()
        {
            if (File.Exists(PATH))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(PATH))
                    {
                        Console.WriteLine("Ice Cream Flavors:");
                        while (!sr.EndOfStream)
                        {
                            string flavor = sr.ReadLine() ?? "";
                            Console.WriteLine(flavor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        /// <summary>
        /// Demonstrates a stream reader without the using() automatic closure in a try/catch/finally block
        /// </summary>
        public static void IceCreamStreamWithoutUsing()
        {
            if (File.Exists(PATH))
            {
                StreamReader? reader = null;
                try
                {
                    reader = new StreamReader(PATH);
                    Console.WriteLine("Ice Cream Flavors:");
                    while (!reader.EndOfStream)
                    {
                        string flavor = reader.ReadLine() ?? "";
                        Console.WriteLine(flavor);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
