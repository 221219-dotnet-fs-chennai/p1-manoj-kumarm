using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    internal class MenuPage : ILayout
    {
        ILogic _repo = new Logic();

        public void Display()
        {
            Console.WriteLine(@$"Main Navigation
    Press [0] - to exit
    Press [1] - to view all trainers
    Press [2] - To sign up
    Press [3] - To login
");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "0":
                    return "MenuPage";
                case "1":
                    return "GetAllTrainerPage";
                case "2":
                    return "AddTrainerSignUpPage";
                case "3":
                    return "TrainerLoginPage";
                default:
                    Console.WriteLine("Invalid input, press enter to try again");
                    Console.ReadKey();
                    return "MenuPage";
            }
        }
    }
}
