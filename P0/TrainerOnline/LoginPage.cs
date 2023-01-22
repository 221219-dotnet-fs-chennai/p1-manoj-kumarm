using DataLayer;
using Serilog;
using System.Data;
using TrainerOnline;


namespace UILayer
{
    internal class LoginPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        internal static readonly Register newLogin = new();
        readonly sql newSql = new(constr);
        public void Display()
        {
            try {
                Console.WriteLine("-------------------------Login-------------------------");
                Console.WriteLine("\tpress [1] - to enter your email: " + newLogin.email);
                Console.WriteLine("\tpress [2] - to enter your password: " + newLogin.password);
                Console.WriteLine("\tpress [3] - to complete login");
                Console.WriteLine("\tpress [b] - to go back");
                Console.WriteLine("\tpress [0] - to exit");
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }

        public string UserOption()
        {
            string input = Console.ReadLine();  
            switch(input)
            {
                case "1":
                    Console.WriteLine("Enter your email [required]");
                    try
                    {
                        newLogin.email = Console.ReadLine();
                        if (!Validation.IsValidEmail(newLogin.email))
                        {
                            newLogin.email = "";
                            Console.WriteLine("Invalid email");
                            Console.WriteLine("press enter to try again");
                            Console.ReadKey();
                            return "LoginPage";
                        }
                        if (newSql.CheckEmailExists(newLogin.email)) { return "LoginPage"; }
                        else {
                            return "SignUpPage";
                        }
                    }
                    catch (NoNullAllowedException e)
                    {
                        throw new Exception(e.Message);
                    }
                case "2":
                    Console.WriteLine("Enter your password [required]");
                    try
                    {
                        newLogin.password = Console.ReadLine();
                        if (!Validation.IsValidPassword(newLogin.password))
                        {
                            newLogin.password = "";
                            Console.WriteLine("Password must contain atleast 8 characters and must contain one special " +
                                "character and one upper case and one lower case character");
                            Console.ReadKey();
                            return "LoginPage";
                        }

                        return "LoginPage";
                    }
                    catch (NoNullAllowedException e)
                    {
                        throw new Exception(e.Message);
                    }
                case "3":
                    if (newLogin.email != null || newLogin.password != null) {
                        if (newSql.CheckUserExists(newLogin.email, newLogin.password))
                        {
                            Log.Information($"trainer with email: {newLogin.email} logged in successfully");
                            return "UserIdPage";
                        }
                        else
                        {
                            Console.WriteLine("Email or Password does'nt match try again, press enter to try again");
                            Log.Error($"trainer with email: {newLogin.email} entered inncorrect login details");
                            Console.ReadKey();
                            return "LoginPage";
                        }
                    }
                    return "LoginPage";
                    
                case "b":
                    return "SignUpPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");

                    Console.ReadKey();
                    return "LoginPage";
            }
        }
    }
}
