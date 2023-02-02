using System.Text.RegularExpressions;

namespace LogicLayer
{
    public class Validation
    {
        private static readonly string path = "../../../../RegexDatabase/Regex.txt";
        public static bool IsValidEmail(string str)
        {
            if(str != null)
            {
                try
                {
                    string EmailPattern = File.ReadLines(path).Skip(0).Take(1).First();
                    if (!Regex.IsMatch(str, EmailPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidPassword(string str)
        {
            if(str != null)
            {
                try
                {
                    string PasswordPattern = File.ReadLines(path).Skip(1).Take(1).First();
                    if (!Regex.IsMatch(str, PasswordPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;

        }

        public static bool IsValidPhone(string str)
        {
            if(str != null)
            {
                try
                {
                    string PhonePattern = File.ReadLines(path).Skip(2).Take(1).First();
                    if (!Regex.IsMatch(str, PhonePattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;

        }

        public static bool IsValidWebsite(string str)
        {
            if(str != null)
            {
                try
                {
                    string WebsitePattern = File.ReadLines(path).Skip(3).Take(1).First();
                    if (!Regex.IsMatch(str, WebsitePattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidGender(string str)
        {
            if(str != null)
            {
                try
                {
                    string GenderPattern = File.ReadLines(path).Skip(4).Take(1).First();
                    if (!Regex.IsMatch(str, GenderPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidGpa(string str)
        {
            if (str != null)
            {
                try
                {
                    string GpaPattern = File.ReadLines(path).Skip(5).Take(1).First();
                    if (!Regex.IsMatch(str, GpaPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidYear(string str)
        {
            if (str != null)
            {
                try
                {
                    string YearPattern = File.ReadLines(path).Skip(6).Take(1).First();
                    if (!Regex.IsMatch(str, YearPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidZipcode(string str)
        {
            if (str != null)
            {
                try
                {
                    string ZipcodePattern = File.ReadLines(path).Skip(7).Take(1).First();
                    if (!Regex.IsMatch(str, ZipcodePattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidSkill(string str)
        {
            if (str != null)
            {
                try
                {
                    string SkillPattern = File.ReadLines(path).Skip(8).Take(1).First();
                    if (!Regex.IsMatch(str, SkillPattern, RegexOptions.IgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

        public static bool IsValidAge(string str)
        {
            if (str != null)
            {
                try
                {
                    _ = int.TryParse(str, out int num);
                    if (num <= 0 | num > 100)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }

    }
}
