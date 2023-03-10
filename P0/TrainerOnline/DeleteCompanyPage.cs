using DataLayer;
using Serilog;
using UILayer;

namespace TrainerOnline
{
    internal class DeleteCompanyPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        readonly sql newSql = new(constr);
        internal static Company newCompany = new();
        public void Display()
        {
            List<Company> list = newSql.GetCompany(UserIdPage.newUserProfile.userid);
            int j = 0;
            Console.WriteLine("-------------------------Experience Details-------------------------");
            foreach (Company i in list)
            {
                Console.WriteLine($"No.{j}");
                Console.WriteLine($@"
    company name: {i.companyname}
    title: {i.title}
    start date: {i.startdate}
    end date: {i.enddate}
    -----------------");
                j++;
            }

            Console.WriteLine(@"
    press [1] - to enter the start year of the company detail that you want to delete
    press [2] - to delete the company detail
    press [b] - to go back
    press [0] - exit");
        }


        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the start year of any one of the experiences");
                    string StartYear = Console.ReadLine();
                    if (Validation.IsValidYear(StartYear)) { 
                        newCompany.startdate = StartYear;
                    }
                    else
                    {
                        newCompany.startdate = "";
                        Console.WriteLine("invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "DeleteCompanyPage";
                case "2":
                    try
                    {
                        newSql.DeleteCompany(UserIdPage.newUserProfile.userid, newCompany.startdate);
                        Console.WriteLine("deleting...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} deleted one company detail");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not delete company detail");
                    }

                    return "DeleteCompanyPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "DeleteCompanyPage";
            }
        }
    }
}
