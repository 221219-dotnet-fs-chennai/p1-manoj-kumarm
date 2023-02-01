using System.Text.RegularExpressions;

namespace LogicLayer
{
    public class Validation
    {
        public static bool IsValidEmail(string str)
        {
            
            string pattern = @"^[\w.]{6,30}[^.](@{0})(gmail|outlook|yahoo).com$";
            if (!Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidPassword(string str)
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
    }
}
