using System.Text.RegularExpressions;

namespace UILayer
{
    internal class Validation
    {
        private Validation() { }
        internal static bool IsValidEmail(string e)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!Regex.IsMatch(e, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidPassword(string p)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            if (!Regex.IsMatch(p, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidId(string id)
        {
            string pattern = @"^(\d{4})$";
            if (!Regex.IsMatch(id, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
