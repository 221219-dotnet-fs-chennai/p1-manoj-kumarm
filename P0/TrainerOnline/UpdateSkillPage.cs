using DataLayer;
using Serilog;
using UILayer;

namespace TrainerOnline
{
    internal class UpdateSkillPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        private static readonly Skills newSkill = new();

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
                    Console.WriteLine(@$"skill - {skill}");
                    j++;
                }
            }
            else {
                Console.WriteLine("your skills are empty please add the skills first before updating them, press b to go back");
            }
            Console.WriteLine($@"
    press [1] to edit skill save changes
    press [b] to go back
    press [0] to exit");
        }

        public string UserOption()
        { 
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    try
                    {
                        Console.WriteLine("enter the new skill name");
                        string newskill = Console.ReadLine();
                        Console.WriteLine("enter the old skill name");
                        string oldSkill = Console.ReadLine();
                        if (Validation.IsValidSkillName(newskill) && Validation.IsValidSkillName(oldSkill))
                        {
                            newSql.UpdateNewSkills(UserIdPage.newUserProfile.userid, oldSkill, newskill);
                            Console.WriteLine("saving...");
                            Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} updated skill detail");
                        }
                        else {
                            Console.WriteLine("Invalid format please press enter to retry");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update skill detail");
                    }
                    return "UpdateSkillPage";
                case "b":
                    return "UserIdPage";
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
