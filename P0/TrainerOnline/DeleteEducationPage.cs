using DataLayer;
using UILayer;

namespace TrainerOnline
{
    internal class DeleteEducationPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        private static readonly Education newEducation = new();
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
    ------------------------");
                j++;
            }
            Console.WriteLine(@"
    press [1] - to enter the start year of the education detail that you want to delete
    press [2] - to delete the education detail
    press [b] - to go back
    press [0] - exit");
        }


        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the start year of any one of the education details");
                    newEducation.startDate = Console.ReadLine();
                    return "DeleteEducationPage";
                case "2":
                    newSql.DeleteEducation(UserIdPage.newUserProfile.userid,newEducation.startDate);
                    Console.WriteLine("deleting...");
                    return "DeleteEducationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "DeleteEducationPage";
            }
        }
    }
}

