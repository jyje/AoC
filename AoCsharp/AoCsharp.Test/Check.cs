using System.Text;

namespace AoCsharp.Test
{
    public static class Check
    {
        public static void IsCorrectAnswer(int value, string hash) => Check.AreEqualHash(value.ToString(), hash);
        public static void AreEqualHash(uint value, string hash) => Check.AreEqualHash(value.ToString(), hash);
        public static void AreEqualHash(string value, string hash)
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