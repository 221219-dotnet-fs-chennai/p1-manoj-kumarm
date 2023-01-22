using System.Text.RegularExpressions;

namespace UILayer
{
    internal class Validation
    {
        private Validation() { }
        internal static bool IsValidEmail(string str)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidPassword(string str)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidId(string str)
        {
            string pattern = @"^(\d{4})$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidPhone(string str) {
            string pattern = @"^([6-9]\d{9})$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidWebsite(string str) {
            string pattern = @"^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidGender(string str) {
            string pattern = "^((male?|female|others))?$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidGpa(string str) {
            string pattern = @"^(\d.\d)|\d)$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    
        internal static bool IsValidYear(string str) {
            string pattern = @"^(19|20)\d{2}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool IsValidZipcode(string str) {
            string pattern = @"^[1-9][0-9]{5}$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
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
