using DataFluentApi;
using LogicLayer;

namespace UILayer
{
    internal class GetAllTrainersPage : ILayout
    {
        ILogic _repo = new Logic();
        EFRepo repo = new EFRepo();
        public void Display()
        {
            Console.WriteLine(@$"
    Search for trainers!
    Press [0] - to Exit
    Press [b] - to go back
    Press [1] - to fetch details of all trainers
    Press [2] - to fetch details of all trainers by age filter
");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "0":
                    return "Exit";
                case "b":
                    return "MenuPage";
                case "1":
                    var listOfTrainers = _repo.GetTrainerDetails();
                    foreach (var t in listOfTrainers)
                    {
                        Console.WriteLine("************************");
                        Console.WriteLine(t.ToString());
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                    return "GetAllTrainerPage";
                case "2":
                    Console.WriteLine("Search by age range[starting - ending]");
                    Console.WriteLine("Enter the starting age");
                    int starting = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the ending age");
                    int ending = Convert.ToInt32(Console.ReadLine());
                    var trainer = _repo.GetTrainerByAge(starting, ending);
                    foreach (var item in trainer)
                    {
                        Console.WriteLine("*************************");
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                    return "GetAllTrainerPage";
                default:
                    Console.WriteLine("invalid input, press enter to try again");
                    Console.ReadKey();
                    return "GetAllTrainersPage";
            }
        }
    }
}
