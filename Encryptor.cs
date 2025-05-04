using System.Text;
using System.Security.Cryptography;

namespace LetGetAPass
{
    //Here's a some GPT-code
    public static class Encryptor
    {
        public static Stream Encrypt(this Stream raw, string pass)
        {
            byte[] key = GenerateKey(pass);
            byte[] iv = new byte[16]; // AES IV size

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }

            MemoryStream encryptedStream = new();

            try
            {
                encryptedStream.Write(iv, 0, iv.Length);  // Prepend the IV to the encrypted stream

                using (AesCng aesCng = new())
                {
                    aesCng.Key = key;
                    aesCng.IV = iv;
                    aesCng.Mode = CipherMode.CBC;
                    aesCng.Padding = PaddingMode.PKCS7;

                    using ICryptoTransform encryptor = aesCng.CreateEncryptor();
                    using CryptoStream cryptoStream = new(encryptedStream, encryptor, CryptoStreamMode.Write, true);
                    raw.CopyTo(cryptoStream);
                    cryptoStream.FlushFinalBlock(); // Important to flush the final block.
                }

                encryptedStream.Seek(0, SeekOrigin.Begin); // Reset the stream to the beginning.
                return encryptedStream;
            }
            catch
            {
                encryptedStream.Dispose();
                throw;
            }
        }

        public static Stream Decrypt(this Stream crypted, string pass)
        {
            byte[] key = GenerateKey(pass);
            byte[] iv = new byte[16];

            // Read the IV from the beginning of the stream.
            crypted.Read(iv, 0, iv.Length);

            MemoryStream decryptedStream = new();

            try
            {
                using (AesCng aesCng = new())
                {
                    aesCng.Key = key;
                    aesCng.IV = iv;
                    aesCng.Mode = CipherMode.CBC;
                    aesCng.Padding = PaddingMode.PKCS7;

                    using ICryptoTransform decryptor = aesCng.CreateDecryptor();
                    using CryptoStream cryptoStream = new(crypted, decryptor, CryptoStreamMode.Read, true);
                    cryptoStream.CopyTo(decryptedStream); // Decrypt and copy the data.
                }

                decryptedStream.Seek(0, SeekOrigin.Begin); // Reset the stream to the beginning.
                return decryptedStream;
            }
            catch
            {
                decryptedStream.Dispose();
                throw;
            }
        }


        private static byte[] GenerateKey(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(RELEASE_ONLY.CLS1.A); // Use a fixed salt value
            using Rfc2898DeriveBytes keyDerivation = new(password, salt, 10000, HashAlgorithmName.SHA256); // Increased iterations
            return keyDerivation.GetBytes(32); // AES-256 key size (32 bytes)
        }
    }
}