using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    class Hash
    {
        public string passHash(string hashData)
        {
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(Encoding.Default.GetBytes(hashData));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString());
            }
            return builder.ToString();
        }
    }
}
