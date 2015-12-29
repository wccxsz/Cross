using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Cross.Framework.Tools
{
    /// <summary>
    /// 加密工具
    /// </summary>
    public class EncryptTool
    {
        private static string password = "wangxiaonuan";

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="convertString"></param>
        /// <returns></returns>
        public static string GetMd5Str(string convertString)
        {
            RSACryptoServiceProvider p = new RSACryptoServiceProvider();
            p.Encrypt(Encoding.UTF8.GetBytes(""), true);

            var md5 = MD5.Create();

            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(convertString)), 4, 8);
        }

        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="encryptString">加密字符串</param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            var mStream = new MemoryStream();
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = GetKeyArray();
            ICryptoTransform transform = aes.CreateEncryptor();
            var cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>
        /// 密码解密
        /// </summary>
        /// <param name="decryptString">解密字符串</param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            var inputByteArray = Convert.FromBase64String(decryptString);
            var mStream = new MemoryStream();
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = GetKeyArray();
            ICryptoTransform transform = aes.CreateDecryptor();
            var cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }

        private static byte[] GetKeyArray()
        {
            if (password == null)
            {
                password = string.Empty;
            }

            if (password.Length < 32)
            {
                password = password.PadRight(32, '0');
            }
            else if (password.Length > 32)
            {
                password = password.Substring(0, 32);
            }

            return Encoding.UTF8.GetBytes(password);
        }

    }
}
