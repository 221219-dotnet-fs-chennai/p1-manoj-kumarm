using LogicLayer;
using Models;

namespace UILayer
{

    internal class AddTrainerSignUpPage : ILayout
    {
        private static DataFluentApi.Entities.TrainerDetail trainer = new();
        private static ILogic logic= new Logic();
        //private static IRepo<DataFluentApi.Entities.TrainerDetail> _repo = new DataFluentApi.EFRepo();
        private static string e = "";
        private static int id = 0000;
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
                    if (!logic.CheckEmailExists(e))
                    {
                        //doesnt exist
                        trainer.Email = e;
                        Console.ReadKey();
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
                    if (!logic.CheckIdExists(id))
                    {
                        trainer.Trainerid = id;
                        Console.WriteLine("this is unique");
                        Console.ReadKey();
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
                    Console.ReadKey();
                    return "AddTrainerSignUpPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "AddTrainerSignUpPage";
            }
        }
    }
}
