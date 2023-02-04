using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILayer
{
    internal class UpdateSkillPage:ILayout
    {
        ITrainerSkill _logic = new TrainerSkillLogic();
        Models.TrainerSkills _skill = new Models.TrainerSkills();
        static string one = "";
        static string two = "";
        static string three = "";
        public void Display()
        {
            var listOfSkills = _logic.GetTrainerSkills(EditAllPage.newtrainer.Trainerid);
            int j = 1;
            Console.WriteLine("-------------------------Skills-------------------------");
            if(listOfSkills.Count() > 0)
            {
                one = listOfSkills.First().ToString();
                two = listOfSkills.ElementAt(1).ToString();
                three = listOfSkills.Last().ToString();
            }
            else
            {
                Console.WriteLine("your skills are empty please add the skills first before updating them, press b to go back");
            }
            Console.WriteLine($@"
    press [1] to edit skill 1 and save changes - {one}
    press [2] to edit skill 2 and save changes - {two}
    press [3] to edit skill 3 and save changes - {three}
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
                    Console.WriteLine("Enter the new skill name");
                    _skill.Skill = Console.ReadLine();
                    _logic.UpdateTrainerSkill(_skill, one);
                    return "UpdateSkillPage";
                case "2":
                    Console.WriteLine("Enter the new skill name");
                    _skill.Skill = Console.ReadLine();
                    _logic.UpdateTrainerSkill(_skill, two);
                    return "UpdateSkillPage";
                case "3":
                    Console.WriteLine("Enter the new skill name");
                    _skill.Skill = Console.ReadLine();
                    _logic.UpdateTrainerSkill(_skill, three);
                    return "UpdateSkillPage";
                case "b":
                    return "EditAllPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "UpdateSkillPage";
            }
        }
    }
}
