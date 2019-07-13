using System.Linq;

namespace _04.Telephony.Vallidators
{
    public static class Vallidator
    {
        public static bool ValidatePhoneNumber(string number)
        {
            return number.All(char.IsNumber);
        }

        public static bool ValidateURL(string url)
        {
            return !url.Any(char.IsNumber);
        }
    }
}