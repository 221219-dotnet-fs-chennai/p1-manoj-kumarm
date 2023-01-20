using DataLayer;
using UILayer;

namespace TrainerOnline
{
    internal class UpdateEduationPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt"); 
        readonly sql newSql = new(constr);
        internal static Education newEducation = new();
        private static string oldName = "";
        private static string newName = "";
        private static string oldDegree = "";
        private static string newDegree = "";
        private static string oldGpa = "";
        private static string newGpa = "";
        private static string oldStartDate = "";
        private static string newStartDate = "";
        private static string oldEndDate = "";
        private static string NewEndDate = "";
        public void Display()
        {
            List<Education> list = new List<Education>();
            list = newSql.GetEducation(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Education Details-------------------------");
            foreach (Education i in list)
            {
                Console.WriteLine($"No. {j}");
                Console.WriteLine($@"
    institute name: {i.institute}
    degree name: {i.degree}
    gpa: {i.gpa}
    start date: {i.startDate}
    end date: {i.endDate}
    ----------------------------");
                j++;
            }

            Console.WriteLine(@"    
    Press [1] - to update institute name
    Press [2] - to update degree name
    Press [3] - to update gpa [eg: 8.2, 9.0, 5.6]
    Press [4] - to update start date [format: yyyy/mm/dd]
    Press [5] - to update end date [format: yyyy/mm/dd]
    Press [6] - to save changes
    Press [b] - to go back
    Press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter your old institute name");
                    oldName = Console.ReadLine();
                    Console.WriteLine("enter your new institute name");
                    newName = Console.ReadLine();
                    return "UpdateEducationPage";
                case "2":
                    Console.WriteLine("enter your old degree name");
                    oldDegree = Console.ReadLine();
                    Console.WriteLine("enter your new degree name");
                    newDegree = Console.ReadLine();
                    return "UpdateEducationPage";
                case "3":
                    Console.WriteLine("enter your old gpa");
                    oldGpa = Console.ReadLine();
                    Console.WriteLine("enter your new gpa");
                    newGpa = Console.ReadLine();
                    return "UpdateEducationPage";
                case "4":
                    Console.WriteLine("enter your old start date");
                    oldStartDate = Console.ReadLine();
                    Console.WriteLine("enter your new start date");
                    newStartDate = Console.ReadLine();
                    return "UpdateEducationPage";
                case "5":
                    Console.WriteLine("enter your old end date");
                    oldEndDate = Console.ReadLine();
                    Console.WriteLine("enter your new new end date");
                    NewEndDate = Console.ReadLine();
                    return "UpdateEducationPage";
                case "6":
                    newSql.UpdateEducation(UserIdPage.newUserProfile.userid, oldName, newName, oldDegree, newDegree, oldGpa, newGpa, oldStartDate, newStartDate, oldEndDate, NewEndDate);
                    Console.WriteLine("saving...");
                    Console.ReadKey();
                    return "UpdateEducationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "UpdateEducationPage";
            }
        }
    }
}
