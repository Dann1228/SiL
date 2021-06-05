using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiL.Lib.Utils.EncryptUtil
{
    public class EncryptUtil
    {
        private static byte[] _salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        public static byte[] AESEncrypt(byte[] inputData, string key)
        {
            if (inputData == null)
            {
                throw new ArgumentNullException("inputData");
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            //byte[] keyByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            //byte[] ivByte = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, _salt);
            byte[] keyByte = pdb.GetBytes(32);
            byte[] ivByte = pdb.GetBytes(16);
            return AESEncrypt(inputData, keyByte, ivByte);
        }

        public static byte[] AESEncrypt(byte[] inputData, byte[] key, byte[] iv = null)
        {
            if (inputData == null)
            {
                throw new ArgumentNullException("inputData");
            }

            if (iv == null)
            {
                iv = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            }
            //if (inputData.Length < 32)
            //{
            //    var temp = new byte[inputData.Length + (32 - inputData.Length % 32)];
            //    Array.Copy(inputData, temp, inputData.Length);
            //    inputData = temp;
            //}
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.Mode = CipherMode.ECB;//非必須，但加了較安全
            //aes.Padding = PaddingMode.PKCS7;//非必須，但加了較安全
            aes.Padding = PaddingMode.Zeros;
            aes.KeySize = 128;
            aes.BlockSize = 128;

            ICryptoTransform transform = aes.CreateEncryptor(key, iv);

            byte[] outputData = transform.TransformFinalBlock(inputData, 0, inputData.Length);//加密

            return outputData;
        }


        public static byte[] AESDecrypt(byte[] inputData, string key)
        {
            if (inputData == null)
            {
                throw new ArgumentNullException("inputData");
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            //byte[] keyByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            //byte[] ivByte = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, _salt);
            byte[] keyByte = pdb.GetBytes(32);
            byte[] ivByte = pdb.GetBytes(16);
            return AESDecrypt(inputData, keyByte, ivByte);
        }

        public static byte[] AESDecrypt(byte[] inputData, byte[] key, byte[] iv = null)
        {
            if (inputData == null)
            {
                throw new ArgumentNullException("inputData");
            }

            if (iv == null)
            {
                iv = new byte[] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            }

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.Mode = CipherMode.ECB;//非必須，但加了較安全
            //aes.Padding = PaddingMode.PKCS7;//非必須，但加了較安全
            aes.Padding = PaddingMode.Zeros;
            aes.KeySize = 128;
            aes.BlockSize = 128;

            ICryptoTransform transform = aes.CreateDecryptor(key, iv);

            //byte[] outputData = transform.TransformFinalBlock(inputData, 0, inputData.Length);//解密
            byte[] outputData = new byte[] { };
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(inputData, 0, inputData.Length);
                }

                outputData = msEncrypt.ToArray();
            }

            return outputData;
        }

        public static string GetStringMD5(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(data);
            return BitConverter.ToString(hash);
        }

        /// <summary>
        /// 以MD5加密方式，比較byte陣列是否相同
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CompareByteArray(byte[] ori, byte[] target)
        {
            var oriString = GetStringMD5(ori);
            var targetString = GetStringMD5(target);

            return oriString == targetString;
        }

    }
}
