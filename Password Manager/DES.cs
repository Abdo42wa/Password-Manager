using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Password_Manager
{
    public class DES
    {

        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        string IV = "helohelohelohelo";
        private static string Key = "helohelohelohelohelohelohelohelo";
        public DES()
        {
            /*des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;*/
        }

        /*  public void EncryptFile(string filePath)
          {
              *//*  des.Key = UTF8Encoding.UTF8.GetBytes(key);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                //StreamReader sr = new StreamReader(filePath);
                byte[] bytes = File.ReadAllBytes(filePath);
                byte[] ebytes = des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                File.WriteAllBytes(filePath, ebytes);*//*


          }*/

        public  void EncryptFile(string filePath, string key)
        {
            byte[] plainContent = File.ReadAllBytes(filePath);
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;


                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());
                    Console.WriteLine("Encrypted succesfully " + filePath);
                }
            }
        }


        public void DecryptFile(string filePath, string key)
        {
            
                byte[] encrypted = File.ReadAllBytes(filePath);
                using (var DES = new DESCryptoServiceProvider())
                {
                    DES.IV = Encoding.UTF8.GetBytes(key);
                    DES.Key = Encoding.UTF8.GetBytes(key);
                    DES.Mode = CipherMode.CBC;
                    DES.Padding = PaddingMode.PKCS7;


                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(),
                            CryptoStreamMode.Write);

                        cryptoStream.Write(encrypted, 0, encrypted.Length);
                        cryptoStream.FlushFinalBlock();
                        File.WriteAllBytes(filePath, memStream.ToArray());
                        Console.WriteLine("Decrypted succesfully " + filePath);
                    }
                }
            
        }
    }
}
