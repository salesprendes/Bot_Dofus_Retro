using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/*
    Este archivo es parte del proyecto Bot Dofus Retro

    Bot Dofus Retro Copyright (C) 2020 - 2023 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_Retro.Utilidades.Criptografia
{
    public class StringHelpercs
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Random random = new Random();

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp) => DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp).UtcDateTime;
        public static string GetRandomChar() => chars[random.Next(0, chars.Count())].ToString();

        public static string GetRandomNetworkKey()
        {
            var str1 = "";
            int rnd = random.Next(1, 128) + 128;
            int index = 0;

            while (index < rnd)
            {
                str1 += GetRandomChar();
                index += 1;
            }

            string result = Checksum(str1) + str1;
            return result + Checksum(result);
        }

        public static string Checksum(string content)
        {
            string hash;

            using (MD5 md5 = MD5.Create())
                hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(content))).Replace("-", String.Empty);

            return hash;
        }
    }
}
