using System;
using System.Security.Cryptography;
using System.Text;

namespace IAT_Test
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProtectedData.Protect(
                plainBytes,
                optionalEntropy: null, // Дополнительные данные для усложнения дешифровки
                scope: DataProtectionScope.CurrentUser // Или DataProtectionScope.LocalMachine
            );
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedBytes = ProtectedData.Unprotect(
                encryptedBytes,
                optionalEntropy: null,
                scope: DataProtectionScope.CurrentUser
            );
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
