using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Game.App.SaveSystem.SaveSystem
{
    public class CryptoServiceAES
    {
        private static readonly int _iterations = 2;
        private static readonly int _keySize = 256;

        private static readonly string password = "OtusSaveSystem";
        private static readonly string _hash = "SHA1";
        private static readonly string _salt = "aselrias38490a32"; // Random
        private static readonly string _vector = "8947az34awl34kjq"; // Random

        public static string Encrypt(string original)
        {
            return Encrypt(original, password);
        }

        public static string Decrypt(string data)
        {
            return Decrypt(data, password);
        }

        public static byte[] GetBytes<TEncoding>(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }

        private static string Encrypt(string value, string password)
        {
            return Encrypt<AesManaged>(value, password);
        }

        private static string Encrypt<T>(string value, string password)
            where T : SymmetricAlgorithm, new()
        {
            var vectorBytes = GetBytes<ASCIIEncoding>(_vector);
            var saltBytes = GetBytes<ASCIIEncoding>(_salt);
            var valueBytes = GetBytes<UTF8Encoding>(value);

            byte[] encrypted;
            using (var cipher = new T())
            {
                var _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                var keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (var encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (var to = new MemoryStream())
                    {
                        using (var writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }

                cipher.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        private static string Decrypt(string value, string password)
        {
            return Decrypt<AesManaged>(value, password);
        }

        private static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            var vectorBytes = GetBytes<ASCIIEncoding>(_vector);
            var saltBytes = GetBytes<ASCIIEncoding>(_salt);
            var valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            var decryptedByteCount = 0;

            using (var cipher = new T())
            {
                var _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                var keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (var decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (var from = new MemoryStream(valueBytes))
                        {
                            using (var reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }

                cipher.Clear();
            }

            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }
    }
}
/*
private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
{
    // Check arguments.
    if (plainText == null || plainText.Length <= 0)
        throw new ArgumentNullException("plainText");
    if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
    if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");
    byte[] encrypted;

    // Create an Aes object
    // with the specified key and IV.
    using (var aesAlg = Aes.Create())
    {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create an encryptor to perform the stream transform.
        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for encryption.
        using (var msEncrypt = new MemoryStream())
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }

                encrypted = msEncrypt.ToArray();
            }
        }
    }

    // Return the encrypted bytes from the memory stream.
    return encrypted;
}

private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
{
    // Check arguments.
    if (cipherText == null || cipherText.Length <= 0)
        throw new ArgumentNullException("cipherText");
    if (Key == null || Key.Length <= 0)
        throw new ArgumentNullException("Key");
    if (IV == null || IV.Length <= 0)
        throw new ArgumentNullException("IV");

    // Declare the string used to hold
    // the decrypted text.
    string plaintext = null;

    // Create an Aes object
    // with the specified key and IV.
    using (var aesAlg = Aes.Create())
    {
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        // Create a decryptor to perform the stream transform.
        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        // Create the streams used for decryption.
        using (var msDecrypt = new MemoryStream(cipherText))
        {
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read the decrypted bytes from the decrypting stream
                    // and place them in a string.
                    plaintext = srDecrypt.ReadToEnd();
                }
            }
        }
    }

    return plaintext;
}*/