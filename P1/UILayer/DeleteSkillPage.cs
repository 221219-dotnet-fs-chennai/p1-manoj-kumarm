using LogicLayer;
namespace UILayer
{
    internal class DeleteSkillsPage : ILayout
    {
        static ITrainerSkill _logic = new TrainerSkillLogic();
        Models.TrainerSkills _skill = new Models.TrainerSkills();

        public void Display()
        {
            List<Models.TrainerSkills> list = _logic.GetTrainerSkills(EditAllPage.newtrainer.Trainerid).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item+"\n");
            }
            Console.WriteLine($@"
    press [1] to delete skill 1
    press [2] to delete skill 2
    press [3] to delete skill 3
    press [b] to go back
    press [0] to exit");
        }

        public string UserChoice()
        {
            _skill.Trainerskillid = EditAllPage.newtrainer.Trainerid;
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    _skill.Skill = Console.ReadLine();
                    _logic.DeleteTrainerskill(_skill);
                    return "DeleteSkillsPage";
                case "2":
                    _skill.Skill = Console.ReadLine();
                    _logic.DeleteTrainerskill(_skill);
                    return "DeleteSkillsPage";
                case "3":
                    _skill.Skill = Console.ReadLine();
                    _logic.DeleteTrainerskill(_skill);
                    return "DeleteSkillsPage";
                case "b":
                    return "EditAllPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "DeleteSkillsPage";
            }
        }
    }
}
