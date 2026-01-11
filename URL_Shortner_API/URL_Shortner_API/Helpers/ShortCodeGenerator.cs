using System.Text;

namespace URL_Shortner_API.Helpers
{
    public static class ShortCodeGenerator
    {
        private const string Characters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static readonly Random _random = new();

        public static string Generate(int length = 6)
        {
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(Characters[_random.Next(Characters.Length)]);
            }

            return sb.ToString();
        }
    }
}
