public interface ILogger
{
    void Write(string message);
}

public class EmailService(ILogger logger)
{
    public void SendEmail(string to, string subject)
    {
        logger.Write($"Sending email to {to} regarding {subject}");
    }
}

public class EmailServiceTraditional
{
    private readonly ILogger _logger;

    public EmailServiceTraditional(ILogger logger)
    {
        _logger = logger;
    }

    public void SendEmail(string to, string subject)
    {
        _logger.Write($"Sending email to {to} regarding {subject}");
    }
}