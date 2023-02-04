using LogicLayer;

namespace UILayer
{
    internal class AddTrainerSignUpPage : ILayout
    {
        private static Models.TrainerDetail trainer = new();
        private static ITrainerDetailLogic logic= new TrainerDetailLogic();
        private static string e = "";
        private static int id = 0;
        public void Display()
        {
            Console.WriteLine(@$"Sign Up!
    Press [0] to exit
    Press [1] to enter email     -  {e}
    Press [2] to enter password  -  {trainer.Password}
    Press [3] to enter user id   -  {id}
    Press [4] to enter signup
    Press [b] to go back
");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "b":
                    return "MenuPage";
                case "1":
                    Console.WriteLine("enter email");
                    e = Console.ReadLine();
                    if (!Utility.CheckEmailExists(e))
                    {
                        trainer.Email = e;
                        return "AddTrainerSignUpPage";
                    }
                    else
                    {
                        trainer.Email = "";
                        Console.WriteLine("Account already exists, please press enter to login");
                        Console.ReadKey();
                        return "TrainerLoginPage";
                    }
                case "2":
                    Console.WriteLine("enter password");
                    trainer.Password = Console.ReadLine();
                    return "AddTrainerSignUpPage";
                case "3":
                    id = Utility.GenerateRandomNo();
                    if (!Utility.CheckIdExists(id))
                    {
                        trainer.Trainerid = id;
                        return "AddTrainerSignUpPage";
                    }
                    else
                    {
                        Console.WriteLine("Account already exists, please press enter to login");
                        Console.ReadKey();
                    }
                    return "AddTrainerSignUpPage";
                case "4":
                    logic.AddTrainerSignUp(trainer);
                    Console.WriteLine("Sign up complete!\nPress enter to login!");
                    Console.ReadKey();
                    return "TrainerLoginPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "AddTrainerSignUpPage";
            }
        }
    }
}
