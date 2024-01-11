using System.IO;

namespace SystemIOExamples
{
    public class FileExamples
    {
        private const string ICE_CREAM_PATH = @"Data/IceCreamFlavors.txt";

        /// <summary>
        /// Demonstrates ReadAllLines() and Exists()
        /// </summary>
        public static void IceCreamReadAllLines()
        {           
            if (File.Exists(ICE_CREAM_PATH))
            {
                string[] flavors = File.ReadAllLines(ICE_CREAM_PATH);
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
        /// Demonstrates a StreamReader()
        /// </summary>
        public static void IceCreamStreamReader()
        {
            if (File.Exists(ICE_CREAM_PATH))
            {
                using (StreamReader sr = new StreamReader(ICE_CREAM_PATH))
                {
                    Console.WriteLine("Ice Cream Flavors:");
                    while (!sr.EndOfStream)
                    {
                        string flavor = sr.ReadLine() ?? "";
                        Console.WriteLine(flavor);
                    }
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
            if (File.Exists(ICE_CREAM_PATH))
            {
                StreamReader? reader = null;
                try
                {
                    reader = new StreamReader(ICE_CREAM_PATH);
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
