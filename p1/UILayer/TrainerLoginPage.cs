﻿using LogicLayer;

namespace UILayer
{
    public class TrainerLoginPage : ILayout
    {
        private static ILogic logic = new Logic();
        private static DataFluentApi.Entities.TrainerDetail trainer = new();
        private static string e = "";
        public void Display()
        {
            try
            {
                Console.WriteLine(@$"Login!
    Press [0] to exit
    Press [1] to enter email     -  {e}
    Press [2] to enter password  -  {trainer.Password}
    Press [3] to enter login
    Press [b] to go back
");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
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
                    trainer.Email = e;
                    if(!logic.CheckEmailExists(e))
                    {
                        Console.WriteLine($"There's no account connected with, {e} email,\npress enter to sign up");
                        Console.ReadKey();
                        return "AddTrainerSignUpPage";
                    }
                    return "TrainerLoginPage";
                case "2":
                    Console.WriteLine("enter password");
                    trainer.Password = Console.ReadLine();
                    return "TrainerLoginPage";
                case "3":
                    if (!logic.CheckTrainerExists(trainer))
                    {
                        Console.WriteLine("Email and Password does not match, press enter to try again");
                        Console.ReadKey();
                        return "TrainerLoginPage";
                    }
                    else
                    {
                        Console.WriteLine("Loading...");
                        return "EditAllPage";
                    }
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "TrainerLoginPage";
            }
        }
    }
}