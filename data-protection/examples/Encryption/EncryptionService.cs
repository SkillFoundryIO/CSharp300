using System.Security.Cryptography;
using System.Text;

namespace Encryption;

public class EncryptionService
{
    private readonly byte[] _key;

    public EncryptionService(string key)
    {
        // Still using SHA256 to derive a consistent key length
        using var sha256 = SHA256.Create();
        _key = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        Console.WriteLine($"Generated Key\n{_key}");
    }

    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;

        // Generate a random initialization vector, for AES this is 16 bytes
        aes.GenerateIV();

        using var msEncrypt = new MemoryStream();
        // Write the IV first
        msEncrypt.Write(aes.IV, 0, aes.IV.Length);

        using var encryptor = aes.CreateEncryptor();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
        csEncrypt.FlushFinalBlock();

        // Convert the combined IV + ciphertext to base64
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        byte[] combinedBytes = Convert.FromBase64String(cipherText);

        if (combinedBytes.Length < 16)
            throw new ArgumentException("Invalid ciphertext length");

        using var aes = Aes.Create();
        aes.Key = _key;

        // Extract the IV from the start
        byte[] iv = new byte[16];
        Array.Copy(combinedBytes, 0, iv, 0, 16);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        // Create MemoryStream skipping 16 bytes to avoid processing the IV
        using var msDecrypt = new MemoryStream(combinedBytes, 16, combinedBytes.Length - 16);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}