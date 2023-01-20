using DataLayer;
using UILayer;

namespace TrainerOnline
{
    internal class UpdateCompanyPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static Company newCompany = new();
        static string oldName = "";
        static string newName = "";
        static string oldTitle = "";
        static string newTitle = "";
        static string oldStartDate = "";
        static string newStartDate = "";
        static string oldEndDate = "";
        static string NewEndDate = "";
        public void Display()
        {
            List<Company> list = newSql.GetCompany(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Experience Details-------------------------");
            foreach (Company i in list) {
                Console.WriteLine($"No. {j}");
                Console.WriteLine($@"
    company name: {i.companyname}
    title: {i.title}
    start date: {i.startdate}
    end date: {i.enddate}
    -------------------------");
                j++;
            }
            Console.WriteLine(@$"
    press [1] - update company name
    press [2] - update title name
    press [3] - update start date
    press [4] - update end date
    press [5] - save changes
    press [b] - go back
    press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter old company name");
                    oldName = Console.ReadLine();
                    Console.WriteLine("enter new company name");
                    newName = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "2":
                    Console.WriteLine("enter old title");
                    oldTitle = Console.ReadLine();
                    Console.WriteLine("enter new title");
                    newTitle = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "3":
                    Console.WriteLine("enter old start date");
                    oldStartDate = Console.ReadLine();
                    Console.WriteLine("enter new new start date");
                    newStartDate = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "4":
                    Console.WriteLine("enter old end date");
                    oldEndDate = Console.ReadLine();
                    Console.WriteLine("enter new end year");
                    NewEndDate = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "5":
                    newSql.UpdateCompany(UserIdPage.newUserProfile.userid, oldName,newName, oldTitle, newTitle, oldStartDate, newStartDate, oldEndDate, NewEndDate);
                    Console.WriteLine("saving...");
                    Console.ReadKey();
                    return "UpdateCompanyPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddCompanyPage";
            }
        }
    }
}
