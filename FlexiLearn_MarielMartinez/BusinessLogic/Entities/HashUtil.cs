using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FlexiLearn_MarielMartinez.BusinessLogic.Entities {
    /// <summary>
    /// This class contains methods which will be used to hash passwords with salts
    /// 
    /// This combines the salt to the plain-text password while both are base 64 strings, rather than combining
    /// them while they are bytes
    /// 
    /// Ref: Based on code shared by Wendi Jollymore (http://www-acad.sheridanc.on.ca/~jollymor/prog32758/security1.html)
    /// </summary>
    public class HashUtil {

        /// <summary>
        /// Hashes a string using SHA-512
        /// </summary>
        /// <param name="password">The plaintext password, or password already combined with salt</param>
        /// <returns>Salted Hash in base 64 string</returns>
        private static string HashPassword (string password) {
            byte[] passBytes = Encoding.UTF8.GetBytes(password);
            SHA512 sHA512 = SHA512.Create();
            byte[] hashedBytes = sHA512.ComputeHash(passBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Generates a salt
        /// </summary>
        /// <returns>Salt in base 64 string</returns>
        public static string GetSalt() {
            RNGCryptoServiceProvider rNG = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[16];
            rNG.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hashes a known salt with a known password
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <param name="salt">The salt in base 64 string</param>
        /// <returns></returns>
        public static string GetPasswordHash(string password, string salt) {
            return HashPassword(password + salt);
        }

    }
}