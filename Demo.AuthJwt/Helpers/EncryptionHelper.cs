using System.Security.Cryptography;
using System.Text;

namespace Demo.AuthJwt.Helpers;

public static class EncryptionHelper
{
    private const string Key = AppConstants.EncryptionKey;

    public static string EncryptString(this string value)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(Key);
        aes.IV = Encoding.UTF8.GetBytes(Key[..16]);

        using var ms = new MemoryStream();
        using var cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);
        using var writer = new StreamWriter(cryptoStream);
        writer.Write(value);
        writer.Close();

        var array = ms.ToArray();

        return Convert.ToBase64String(array);
    }

    public static string DecryptString(this string value)
    {
        var array = Convert.FromBase64String(value);

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(Key);
        aes.IV = Encoding.UTF8.GetBytes(Key[..16]);

        using var ms = new MemoryStream(array);
        using var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream);

        return reader.ReadToEnd();
    }
}