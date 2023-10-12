using System.Security.Cryptography;
using System.Text;

public class Encriptation
{
    public static string Encrypt(string password)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(password);
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("X2"));
        }
        string encryptedPassword = sb.ToString();
        return encryptedPassword;
    }
    public static string Decrypt(string encryptedPassword)
    {
        MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(encryptedPassword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            string decryptedPassword = sb.ToString();
            return decryptedPassword;
        }
}