using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mawa.Hash
{

    public class ComputeHash
    {
        public static class Algorithms
        {
            public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
            public static readonly HashAlgorithm SHA1 = new SHA1Managed();
            public static readonly HashAlgorithm SHA256 = new SHA256Managed();
            public static readonly HashAlgorithm SHA384 = new SHA384Managed();
            public static readonly HashAlgorithm SHA512 = new SHA512Managed();
            //public static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();
        }

        #region Hash


        public static string GetHash(Stream stream, HashAlgorithm algorithm)
        {
            return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
        }

        public static string GetHash(string filePath, HashAlgorithm algorithm, FileShare fileShare)
        {
            using (var fil = File.Open(filePath, FileMode.Open, FileAccess.Read, fileShare))
            {
                using (var stream = new BufferedStream(fil, 100000))
                {
                    var hash = GetHash(stream, algorithm);
                    stream.Close();
                    return hash;
                    //return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
                }
                fil.Close();
            }
        }
        public static string GetHash(string filePath, HashAlgorithm algorithm)
        {
            using (var stream = new BufferedStream(File.OpenRead(filePath), 100000))
            {
                var hash = GetHash(stream, algorithm);
                stream.Close();
                return hash;
                //return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
            }
        }
        public static string GetHash(byte[] byteArray, HashAlgorithm algorithm)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return GetHash(stream, algorithm);
            }
        }
        public static string GetHashFromText(string txt, HashAlgorithm algorithm)
        {
            // convert string to stream
            //byte[] byteArray = Encoding.UTF8.GetBytes(txt);
            //byte[] data = Encoding.ASCII.GetBytes(str);
            byte[] byteArray = Encoding.ASCII.GetBytes(txt);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            //MemoryStream stream = new MemoryStream(byteArray);

            /*
             convert stream to string
             StreamReader reader = new StreamReader(stream);
             string text = reader.ReadToEnd();
            */

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                return GetHash(stream, algorithm);
                //return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
            }
        }

        #endregion

        #region MD5

        /// <summary>
        /// Gget MD5 for stream data
        /// </summary>
        /// <param name="stream">data as stream</param>
        /// <returns>MD5 Hash</returns>
        public static string GetHash_MD5(Stream stream)
        {
            return GetHash(stream, Algorithms.MD5);
        }

        public static string GetHashFromText_MD5(string txt)
        {
            return GetHashFromText(txt, Algorithms.MD5);
        }
        public static string GetHash_MD5(string filePath)
        {
            return GetHash(filePath, Algorithms.MD5);
        }
        public static string GetHash_MD5(byte[] byteArray)
        {
            return GetHash(byteArray, Algorithms.MD5);
        }

        #endregion

    }
}
