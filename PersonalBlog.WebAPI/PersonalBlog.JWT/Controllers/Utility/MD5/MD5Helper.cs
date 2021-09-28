using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace PersonalBlog.JWT.Utility.MD5
{
    public static class MD5Helper
    {
        public static string EncryptMD5(string s)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var result = "";
            if (!string.IsNullOrWhiteSpace(s))
            {
                result = BitConverter.ToString(md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(s.Trim())));
            }
            return result;
        }


    }
}
