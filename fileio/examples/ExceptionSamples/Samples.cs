namespace ExceptionSamples;

public class Samples
{
    public static void Throw()
    {
        throw new Exception("Something went wrong...");
    }

    public void RegisterUser(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Name cannot be null or whitespace", 
                nameof(name));
        }          
    }
}