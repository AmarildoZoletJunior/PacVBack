using System.Security.Cryptography;
using System.Text;

namespace Booking.CrossCutting.Helper
{
    public static class CryptoHelper
    {
        public static string EncryptPassword(string password)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(password);
            using (Aes aesAlg = Aes.Create())
            {

                aesAlg.Key = Encoding.UTF8.GetBytes("2B7E151628AED2A6ABF7158809CF4F3C");
                aesAlg.IV = new byte[16];
                using (System.Security.Cryptography.ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    csEncrypt.FlushFinalBlock();
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }
        public static string DecryptPasswod(string password)
        {

            byte[] encryptedBytes = Convert.FromBase64String(password);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("2B7E151628AED2A6ABF7158809CF4F3C");
                aesAlg.IV = new byte[16];
                using (System.Security.Cryptography.ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    byte[] plainBytes = new byte[encryptedBytes.Length];
                    int decryptedByteCount = csDecrypt.Read(plainBytes, 0, plainBytes.Length);
                    return Encoding.UTF8.GetString(plainBytes, 0, decryptedByteCount);
                }
            }
        }
    }
}
