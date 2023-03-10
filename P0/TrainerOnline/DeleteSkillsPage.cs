using DataLayer;
using Serilog;
using UILayer;

namespace TrainerOnline
{
    internal class DeleteSkillsPage : ILayout
    {
        static string constr = File.ReadAllText(("../../../Database/cs.txt"));
        private static readonly sql newSql = new(constr);
        private static readonly Skills newSkill = new Skills();
        public void Display()
        {

            List<string> listOfSkills = newSql.GetAllSkills(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Skills-------------------------");
            if (listOfSkills.Count != 0)
            {
                foreach (string skill in listOfSkills)
                {
                    Console.WriteLine($"No. {j}");
                    Console.WriteLine($@"{skill}");
                    Console.WriteLine("--------------------------------");
                    j++;
                }
            }
            else
            {
                Console.WriteLine("your skills empty please add the skills first before updating them, press b to go back");
            }

            Console.WriteLine(@"
    press [1] - to enter the skill that you want to delete
    press [2] - to delete the skill
    press [b] - to go back
    press [0] - exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the skill name");
                    string SkillName = Console.ReadLine();
                    if (Validation.IsValidSkillName(SkillName)) { 
                        newSkill.skillName = SkillName;
                    }
                    else
                    {
                        newSkill.skillName = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "DeleteSkillsPage";
                case "2":
                    try
                    {
                        newSql.DeleteSkill(newSkill);
                        Console.WriteLine("deleting...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} deleted one skill detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not delete skill detail");

                    }
                    return "DeleteSkillsPage";
                case "b":
                    return "UserIdPage";
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
