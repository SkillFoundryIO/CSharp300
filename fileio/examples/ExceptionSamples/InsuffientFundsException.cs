namespace ExceptionSamples;

// Inherit from exception base class
public class InsuffientFundsException : Exception
{
    // Add a constructor for the Message overload
    public InsuffientFundsException(string message) : base(message)
    {

    }
}