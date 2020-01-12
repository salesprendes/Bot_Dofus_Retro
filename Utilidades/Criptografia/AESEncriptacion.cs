using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bot_Dofus_Retro.Utilidades.Criptografia
{
    public static class AESEncriptacion
    {
        private static readonly int iteraciones = 10;
        private static readonly int talla = 256;

        private static readonly string salto = "aselrias38490a32";
        private static readonly string vector = "8947az34awl34kjq";

        public static string Encriptar(string _valor, string password)
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salto);
            byte[] valueBytes = Encoding.ASCII.GetBytes(_valor);

            byte[] encriptado;
            using (Aes cipher = Aes.Create())
            {
                Rfc2898DeriveBytes _passwordBytes = new Rfc2898DeriveBytes(password, saltBytes, iteraciones);
                byte[] keyBytes = _passwordBytes.GetBytes(talla / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encriptado = to.ToArray();
                        }
                    }
                }
            }

            return Convert.ToBase64String(encriptado);
        }

        public static string Desencriptar(string value, string password)
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(salto);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (var cipher = Aes.Create())
            {
                Rfc2898DeriveBytes _passwordBytes = new Rfc2898DeriveBytes(password, saltBytes, iteraciones);
                byte[] keyBytes = _passwordBytes.GetBytes(talla / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }

            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }
    }
}
