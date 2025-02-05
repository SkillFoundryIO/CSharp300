using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace AirportLockerSQLite.Actions;

public class HashManager
{
    private const int _MEMORY_SIZE = 65536;
    private const int _DEGREE_OF_PARALLELISM = 4;
    private const int _ITERATIONS = 4;
    private const int _SALT_SIZE = 16;
    private const int _HASH_SIZE = 32;

    public byte[] CreateSalt()
    {
        return RandomNumberGenerator.GetBytes(_SALT_SIZE);
    }

    public string HashPassword(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        using var argon2 = new Argon2id(passwordBytes)
        {
            Salt = salt,
            DegreeOfParallelism = _DEGREE_OF_PARALLELISM,
            Iterations = _ITERATIONS,
            MemorySize = _MEMORY_SIZE
        };

        byte[] hash = argon2.GetBytes(_HASH_SIZE);
        return Convert.ToHexString(hash);
    }
}
