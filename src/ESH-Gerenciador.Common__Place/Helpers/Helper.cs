﻿using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ESH_Gerenciador.Common__Place.Helpers
{
    public static class Helper
    {
        public static string GetConference(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace(" ", "").ToLower();
        }

        public static string ToUrl(this string texto)
        {
            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            var novoTexto = stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace(" ", "_").ToLower();

            return Regex.Replace(novoTexto, @"[^0-9a-zA-Z\._]", "");
        }
    }

    public class HelperAesCrypto
    {
        private static byte[] Encrypt(byte[] clearText, byte[] key, byte[] iv)
        {
            Aes alg = Aes.Create();
            alg.Key = key;
            alg.IV = iv;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearText, 0, clearText.Length);
                }
                byte[] encryptedData = ms.ToArray();

                return encryptedData;
            }
        }


        public static string Encrypt(string clearText, string password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            var pdb = new PasswordDeriveBytes(password, new byte[] { 0x76, 0x37, 0x6a, 53, 0x12, 0x1d, 0x56, 0x44, 0x59, 0x41, 0x62, 0x67, 0x26 });
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] key, byte[] iv)
        {
            Aes alg = Aes.Create();
            alg.Key = key;
            alg.IV = iv;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherData, 0, cipherData.Length);
                }
                byte[] decryptedData = ms.ToArray();

                return decryptedData;
            }
        }


        public static string Decrypt(string cipherText, string password)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var pdb = new PasswordDeriveBytes(password, new byte[] { 0x76, 0x37, 0x6a, 53, 0x12, 0x1d, 0x56, 0x44, 0x59, 0x41, 0x62, 0x67, 0x26 });
            var decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }
    }
}
