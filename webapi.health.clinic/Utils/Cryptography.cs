using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace webapi.health.clinic.Utils
{
    public static class Cryptography
    {
        // Salt
        private static int SaltSize = 16;

        // Password
        private static int DegreeOfParallelism = 1;
        private static int Iterations = 2;
        private static int MemorySize = 1024 * 20;
        private static int HashSize = 48;

        /// <summary>
        /// Create a salt for be added to a hash
        /// </summary>
        /// <returns>A array of random secure bytes</returns>
        public static byte[] CreateSalt()
        {
            byte[] buffer = RandomNumberGenerator.GetBytes(SaltSize);

            return buffer;
        }

        /// <summary>
        /// Turn a password string into a cryptographic hash
        /// </summary>
        /// <param name="password">The original password</param>
        /// <param name="salt">The salt of password</param>
        /// <returns>The Hashed password</returns>
        public static byte[] HashPassword(string password, byte[] salt)
        {
            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = DegreeOfParallelism;
            argon2.Iterations = Iterations;
            argon2.MemorySize = MemorySize;

            return argon2.GetBytes(HashSize);
        }

        /// <summary>
        /// Verify if a text matches a hash
        /// </summary>
        /// <param name="testPassword">Password to be compared</param>
        /// <param name="salt">Salt used</param>
        /// <param name="hashedPassword">Hashed Password</param>
        /// <returns>A response of verification (true or false)</returns>
        public static bool VerifyHash(string testPassword, byte[] salt, byte[] hashedPassword)
        {
            byte[] hashedTestPassword = HashPassword(testPassword, salt);

            return hashedPassword.SequenceEqual(hashedTestPassword);
        }
    }
}
