using System.Text;

namespace AoCsharp.Test
{
    public static class Check
    {
        /// <summary>
        /// Use SHA256 checksum to evaluate if the answer is correct.
        /// </summary>
        public static void IsCorrectAnswer(int value, string hash) => Check.IsCorrectAnswer(value.ToString(), hash);
        /// <summary>
        /// Use SHA256 checksum to evaluate if the answer is correct.
        /// </summary>
        public static void IsCorrectAnswer(uint value, string hash) => Check.IsCorrectAnswer(value.ToString(), hash);
        /// <summary>
        /// Use SHA256 checksum to evaluate if the answer is correct.
        /// </summary>
        public static void IsCorrectAnswer(string value, string hash)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

            Assert.AreEqual(hashString, hash);

            Console.WriteLine("Correct Answer!");
        }
    }
}