using DataLayer;
using UILayer;

namespace TrainerOnline
{
    internal class AddEducationPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static Education newEducation = new();
        public void Display()
        {
            Console.WriteLine(@"-------------------------Add Education-------------------------
    Press [1] - to add institute name
    Press [2] - to add degree name
    Press [3] - to add gpa [eg: 8.2, 9.0, 5.6]
    Press [4] - to add start date [format: yyyy/mm/dd]
    Press [5] - to add end date [format: yyyy/mm/dd]
    Press [6] - to add save changes
    Press [b] - to go back
    Press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter your institute name");
                    newEducation.institute = Console.ReadLine();
                    return "AddEducationPage";
                case "2":
                    Console.WriteLine("enter your degree name");
                    newEducation.degree = Console.ReadLine();
                    return "AddEducationPage";
                case "3":
                    Console.WriteLine("enter your gpa");
                    newEducation.gpa = Console.ReadLine();
                    return "AddEducationPage";
                case "4":
                    Console.WriteLine("enter your start date");
                    newEducation.startDate = Console.ReadLine();
                    return "AddEducationPage";
                case "5":
                    Console.WriteLine("enter your end date");
                    newEducation.endDate = Console.ReadLine();
                    return "AddEducationPage";
                case "6":
                    newSql.AddEducation(UserIdPage.newUserProfile.userid, newEducation);
                    Console.WriteLine("saving...");
                    Console.ReadKey();
                    return "AddEducationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddEducationPage";
            }
        }
    }
}
