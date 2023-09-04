//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Mawa.Hash
//{
//    public static class ComputeMD5
//    {
//         GetMD5HashFromFile(string fileName)
//        {
//            string result = null;
//            try
//            {
//                using (System.IO.FileStream file = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
//                {
//                    using (System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
//                    {
//                        byte[] retVal = md5.ComputeHash(file);
//                        result = BitConverter.ToString(retVal).Replace("-", "");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("GetMD5HashFromFile() fail, error:" + ex.Message);
//            }
//            return result;
//        }
//    }
//}
