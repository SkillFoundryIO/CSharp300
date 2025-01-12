StreamReader? sr = null;

try
{
   sr = new StreamReader("Badfile.txt");
   string contents = sr.ReadToEnd();
   Console.WriteLine(contents);
}
catch (FileNotFoundException ex)
{
   Console.WriteLine($"File not found: {ex.Message}");
}
catch (IOException ex)
{
   Console.WriteLine($"I/O error: {ex.Message}");
}
catch (Exception ex)
{
   Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
   if (sr != null)
   {
       sr.Close();
   }
}