using LogicLayer;

namespace UILayer
{
    internal class AddTrainerSkillsPage : ILayout
    {
        private static readonly Models.TrainerSkills skills = new();
        private static readonly ILogic logic = new Logic();
       public void Display()
       {
                Console.WriteLine($@"-------------------------Add skills-------------------------

    press [1] - add new skill [must be atleast 3 characters long] - {skills.Skill}
    press [2] - to save changes
    press [b] - to go back
    press [0] - to exit");
       }

        public string UserChoice()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Enter skill name");
                    string newSkillName = Console.ReadLine();
                    skills.Skill = newSkillName;
                    /*if (Validation.IsValidSkillName(newSkillName))
                    {
                        newSkill.skillName = newSkillName;
                    }
                    else
                    {
                        newSkill.skillName = "";
                        Console.WriteLine("Invalid format, skill should be more than 3 characters long, press enter to try again");
                        Console.ReadKey();
                    }*/
                    return "AddTrainerSkillsPage";
                case "2":
                    skills.Trainerskillid = EditAllPage.newtrainer.Trainerid;
                    if (!Utility.ReachedMaxCount(skills.Trainerskillid))
                    {
                        logic.AddTrainerSkills(skills);
                    }
                    else
                    {
                        Console.WriteLine("You can add atmost 3 skills, try updating"); //make a costom exception
                        Console.ReadKey();
                    }
                    /*try
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

                    }*/
                    return "AddTrainerSkillsPage";
                case "b":
                    return "EditAllPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press <Enter> to continue");
                    Console.ReadKey();
                    return "AddTrainerSkillsPage";
            }
        }
    }
}
