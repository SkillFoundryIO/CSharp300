namespace SystemIOExamples
{
    public class DirectoryExamples
    {
        public static void PrintCurrentDirectory()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
        }

        public static void PrintLogicalDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                Console.WriteLine(drive);
            }
        }

        public static void PrintCurrentDirectoryFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }


    }
}
