namespace SystemIOExamples
{
    public class DirectoryInfoExamples
    {
        public static void GetFileInfoList()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            FileInfo[] files = directory.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
