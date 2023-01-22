using DataLayer;
using Serilog;
using UILayer;

namespace TrainerOnline
{
    internal class AddSkillPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        private static readonly Skills newSkill = new Skills();
        public void Display()
        {
            Console.WriteLine("-------------------------Add skills-------------------------");
            Console.WriteLine($@"    
    press [1] - add new skill - {newSkill.skillName}
    press [2] - to save changes
    press [b] - to go back
    press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Enter skill name");
                    newSkill.skillName = Console.ReadLine();
                    return "AddSkillPage";
                case "2":
                    try
                    {
                        newSkill.trainerskillid = UserIdPage.newUserProfile.userid;
                        newSql.AddSkills(newSkill);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} added new skill detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not add skill detail");

                    }
                    return "AddSkillPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddSkillPage";
            }
        }
    }
}
