using DataLayer;
using Serilog;
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
            if (list.Count != 0) {
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
            }
            else
            {
                Console.WriteLine("your experience details are empty please add the experience details first before updating them, press b to go back");
            }
            Console.WriteLine(@$"
    press [1] - update company name - {newName}
    press [2] - update title name - {newTitle}
    press [3] - update start date - {newStartDate}
    press [4] - update end date - {NewEndDate}
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
                    Console.WriteLine("enter old start year");
                    string Oldyear = Console.ReadLine();
                    if (Validation.IsValidYear(Oldyear)) {
                        oldStartDate = Oldyear;
                    }
                    else
                    {
                        oldStartDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter new start year");
                    string Newyear = Console.ReadLine();
                    if (Validation.IsValidYear(Newyear))
                    {
                        newStartDate = Newyear;
                    }
                    else
                    {
                        newStartDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    //newStartDate = Console.ReadLine();
                    return "UpdateCompanyPage";
                case "4":
                    Console.WriteLine("enter old end year");
                    string OldEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(OldEndYear)) {
                        oldEndDate = OldEndYear;
                    }
                    else {
                        oldEndDate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter new end year");
                    //NewEndDate = Console.ReadLine();
                    string newEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(newEndYear)) {
                        NewEndDate = newEndYear;
                    }
                    else
                    {
                        NewEndDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "UpdateCompanyPage";
                case "5":
                    try
                    {
                        newSql.UpdateCompany(UserIdPage.newUserProfile.userid, oldName, newName, oldTitle, newTitle, oldStartDate, newStartDate, oldEndDate, NewEndDate);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} updated experience detail");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update experience detail");
                    }
                    
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
