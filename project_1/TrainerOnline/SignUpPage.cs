using System.Data;
using DataLayer;
using TrainerOnline;

namespace UILayer
{
    internal class SignUpPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly Register newSignUp = new();
        readonly sql newSql = new(constr);
        public void Display()
        {
            try
            {
                Console.WriteLine("-------------------------Sign Up-------------------------");
                Console.WriteLine("Please enter the details");
                Console.WriteLine("\t -Press [1] \tto enter your email" + " " + newSignUp.email);
                Console.WriteLine("\t -Press [2] \tto enter your password" + " " + newSignUp.password);
                Console.WriteLine("\t -Press [4] \tto enter your user id" + " " + newSignUp.userid);
                Console.WriteLine("\t -Press [3] \tto to save");
                Console.WriteLine("\t -Press [b] \tto go back to the main page");
            }
            catch(IOException e) {
                throw new Exception(e.Message);
            }
        }
        public string UserOption()
        {
            try
            {
                string userInput;
                userInput = Console.ReadLine().ToString();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter your email [required]");
                        try
                        {
                            string email = newSignUp.email = Console.ReadLine();
                            Console.WriteLine(newSql.CheckIdExists(email));
                            if (!Validation.IsValidEmail(email)) {
                                Console.WriteLine("Invalid email");
                                Console.WriteLine("press enter to try again");
                                Console.ReadKey();
                                return "SignUpPage";
                            }
                            if (newSql.CheckEmailExists(email))
                            {
                                return "LoginPage";
                            }
                            else { 
                                return "SignUpPage";                                
                            }
                        }
                        catch(NoNullAllowedException e) {
                            throw new Exception(e.Message);
                        }
                    case "2":
                        Console.WriteLine("Enter your password [required]");
                        try
                        {
                            newSignUp.password = Console.ReadLine();
                            if (!Validation.IsValidPassword(newSignUp.password)) {
                                newSignUp.password = "";
                                Console.WriteLine("Password must contain atleast 8 characters and must contain one special " +
                                    "character and one upper case and one lower case character");
                                Console.WriteLine("press enter to try again");
                                Console.ReadKey();
                                return "SignUpPage";
                            }
                            return "SignUpPage";
                        }
                        catch (NoNullAllowedException e) 
                        { 
                            throw new Exception(e.Message); 
                        }
                    case "b":
                        return "Menu";
                    case "3":
                        try
                        {
                            if (newSignUp.email == null || newSignUp.password == null) return "SignUpPage";
                            else { 
                                newSql.Adduser(newSignUp);
                                newSignUp.email = "";
                                newSignUp.password = "";
                                return "UserIdPage";
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadKey();
                        }
                        return "Menu";
                    case "4":
                        try
                        {
                            Console.WriteLine("to enter a unique 4 digit number and this will be your user id");
                            try
                            {
                                
                                int id = Convert.ToInt32(Console.ReadLine());
                                string newId = id.ToString();
                                if (Validation.IsValidId(newId)) {
                                    newSignUp.userid = id;
                                }
                                else {
                                    Console.WriteLine("invalid user id, please try again");
                                }
                                if (newSql.CheckTrainerIdExists(newSignUp.email, id))
                                {
                                    return "LoginPage";
                                }
                                else
                                {
                                    Console.WriteLine("user id taken try another one");
                                    return "SignUpPage";
                                }

                            }
                            catch (NoNullAllowedException e)
                            {
                                throw new Exception(e.Message);
                            }
                        }
                        catch(IOException e) {
                            Console.WriteLine(e.Message);
                        }
                        return "SignUpPage";
                    default:
                        Console.WriteLine("Invalid response, please enter a valid input");
                        Console.WriteLine("Please press \"Enter\" to continue");
                        Console.ReadKey();
                        return "SignUpPage";
                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                throw new Exception(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
