using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Konscious.Security.Cryptography;

namespace Hashing;

public class PasswordManager
{
    private const string _FILE = "users.txt";

    private const int _MEMORY_SIZE = 65536;    // 64MB
    private const int _DEGREE_OF_PARALLELISM = 4;
    private const int _ITERATIONS = 4;
    private const int _SALT_SIZE = 16;         // 128 bits
    private const int _HASH_SIZE = 32;         // 256 bits

    private readonly Dictionary<string, UserInfo> _users = new();

    private byte[] CreateSalt()
    {
        return RandomNumberGenerator.GetBytes(_SALT_SIZE);
    }

    private string HashPassword(string password, byte[] salt)
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

    public bool VerifyPassword(string email, string password)
    {
        if (!_users.ContainsKey(email))
        {
            return false;
        }

        var user = _users[email];
        byte[] salt = Convert.FromHexString(user.Salt);
        string hash = HashPassword(password, salt);
        return user.PasswordHash == hash;
    }

    public void CreateUser(string email, string password)
    {
        var salt = CreateSalt();
        string hash = HashPassword(password, salt);

        var user = new UserInfo(email, hash, Convert.ToHexString(salt));
        _users[email] = user;
        Save();
    }

    private void Save()
    {
        // Create a list of user entries to serialize
        var userEntries = _users.Values.Select(user => new
        {
            user.Email,
            user.PasswordHash,
            user.Salt
        }).ToList();

        // Serialize to JSON with proper escaping
        string json = JsonSerializer.Serialize(userEntries, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        // Write atomically using a temporary file
        string tempFile = _FILE + ".tmp";
        File.WriteAllText(tempFile, json);
        File.Move(tempFile, _FILE, true);
    }

    public void Load()
    {
        if (!File.Exists(_FILE))
            return;

        try
        {
            string json = File.ReadAllText(_FILE);
            var userEntries = JsonSerializer.Deserialize<List<UserInfo>>(json);

            _users.Clear();
            foreach (var user in userEntries)
            {
                _users[user.Email] = user;
            }
        }
        catch (JsonException ex)
        {
            // Log the error and possibly create a backup of the corrupted file
            throw new InvalidOperationException("Failed to load user data", ex);
        }
    }
}
