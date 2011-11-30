using System;
using System.Security.Cryptography;
using System.Text;

namespace DiscountMe.Common {
    public static class Constantes {
        public static readonly DateTime FechaPorDefecto = new DateTime(1754, 01, 01, 20, 34, 39, 232);

        public static string PasswordSalt {
            get {
                var rng = new RNGCryptoServiceProvider();
                var buff = new byte[32];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
        }

        public static string EncodePassword(string password, string salt) {
            var bytes = Encoding.Unicode.GetBytes(password);
            var src = Encoding.Unicode.GetBytes(salt);
            var dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            var algorithm = new HMACSHA1(src);
            var inarray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inarray);
        }
    }
}