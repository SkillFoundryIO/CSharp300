namespace Hashing;

public class UserInfo(string email, string passwordHash, string salt)
{
    public string Email { get; set; } = email;
    public string PasswordHash { get; set; } = passwordHash;
    public string Salt { get; set; } = salt;
}
