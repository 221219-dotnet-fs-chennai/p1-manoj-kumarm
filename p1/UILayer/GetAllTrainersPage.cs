using LogicLayer;

namespace UILayer
{
    internal class GetAllTrainersPage : ILayout
    {
        static ITrainerSkill _logic = new TrainerSkillLogic();
        static ITrainerDetailLogic _repo = new TrainerDetailLogic();
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
                    var all = _repo.GetAllInfo();
                    foreach (var item in all)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    /*foreach (var item in list)
                    {
                        foreach (var detail in item.details)
                        {
                            Console.WriteLine(detail);
                        }
                        *//*foreach (var skill in item.skills)
                        {
                            Console.WriteLine(skill);
                        }*//*
                    }*/
                    /*var listOfTrainers = _repo.GetTrainerDetails();
                    foreach (var item in listOfTrainers)
                    {
                        Console.WriteLine("\t\t\tDetails");
                        Console.WriteLine(item.ToString());
                        var skills = _logic.GetTrainerSkills(item.Trainerid);
                        Console.WriteLine("\t\t\tskills");
                        Console.WriteLine();
                        foreach (var skill in skills)
                        {
                            Console.WriteLine($"\t{skill.ToString()}");
                        }
                        Console.WriteLine("---------------------------------------------------------------------------------");
                    }
                    _repo.GetTrainerDetails();
                    Console.WriteLine("Press enter to continue...");*/
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
                        Console.WriteLine("\t\t\tDetails");
                        Console.WriteLine(item.ToString());
                        var skills = _logic.GetTrainerSkills(item.Trainerid);
                        Console.WriteLine("\t\t\tskills");
                        Console.WriteLine();
                        foreach (var skill in skills)
                        {
                            Console.WriteLine($"\t{skill.ToString()}");
                        }
                        Console.WriteLine("---------------------------------------------------------------------------------");
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
