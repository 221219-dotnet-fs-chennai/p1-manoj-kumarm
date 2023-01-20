using TrainerOnline;

namespace UILayer
{
    internal class Menu : ILayout
    {
        public void Display()
        {
            try
            {
                Console.WriteLine("Welcome to Mentor Online!");
                Console.WriteLine("Please Signup/Login");
                Console.WriteLine("\t Press [s]-\tto SingUp");
                Console.WriteLine("\t Press [l]-\tto Login");
                Console.WriteLine("\t Press [m]-\tto Menu");
                Console.WriteLine("\t Press [0]-\tExit");
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
        }

        public string UserOption()
        {
            string constr = File.ReadAllText("../../../Database/cs.txt");
            //string constr = $"Server=MANOJ;Database=project0;Trusted_Connection=True;";
            sql newSql = new(constr);
            try
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        return "Exit";
                    case "s":
                        return "SignUpPage";
                    case "l":
                        return "LoginPage";
                    case "m":
                        return "Menu";
                    /*case "e": // need to remove this after completion
                        newSql.GetAllPersons().ForEach(user => Console.WriteLine(user));
                        return "";*/
                    default:
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press \"Enter\" to continue");
                        Console.ReadLine();
                        return "Menu";
                }
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e){
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e) { 
                Console.WriteLine(e.Message);
            }
            return "Menu";
        }
    }
}
