using DataLayer;
using UILayer;

namespace TrainerOnline
{
    internal class AddCompanyPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static Company newCompany = new();
        public void Display()
        {
            Console.WriteLine($@"-------------------------Add Experience Details-------------------------
    press [1] - add company name - {newCompany.companyname}
    press [2] - to enter title - {newCompany.title}
    press [3] - to enter start year [format - yyyy] - {newCompany.startdate} 
    press [4] - to enter end year [format - yyyy] - {newCompany.enddate}
    press [5] - to save the changes
    press [b] - to go back
    press [0] - exit
    ");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("Enter company name");
                    newCompany.companyname = Console.ReadLine();
                    return "AddCompanyPage";
                case "2":
                    Console.WriteLine("Enter the title");
                    newCompany.title = Console.ReadLine();
                    return "AddCompanyPage";
                case "3":
                    Console.WriteLine("Enter the start year");
                    newCompany.startdate = Console.ReadLine();
                    return "AddCompanyPage";
                case "4":
                    Console.WriteLine("Enter the end year");
                    newCompany.enddate = Console.ReadLine();
                    return "AddCompanyPage";
                case "5":
                    newSql.AddCompany(UserIdPage.newUserProfile.userid, newCompany);
                    Console.WriteLine("saving...");
                    Console.ReadKey();
                    return "AddCompanyPage";
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
