using DataLayer;
using Serilog;
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
            Console.WriteLine($@"-------------------------Add Education-------------------------
    Press [1] - to add institute name - {newEducation.institute}
    Press [2] - to add degree name - {newEducation.degree}
    Press [3] - to add gpa [eg: 8.2, 9.0, 5.6] - {newEducation.gpa}
    Press [4] - to add start year [format: yyyy] - {newEducation.startDate}
    Press [5] - to add end year [format: yyyy] - {newEducation.endDate}
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
                    string Gpa = Console.ReadLine();    
                    if (Validation.IsValidGpa(Gpa)) {
                        newEducation.gpa = Gpa;
                    }
                    else
                    {
                        newEducation.gpa = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "4":
                    Console.WriteLine("enter your start year");
                    string StartYear = Console.ReadLine();
                    if (Validation.IsValidYear(StartYear)) { 
                        newEducation.startDate = StartYear;
                    }
                    else
                    {
                        newEducation.startDate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "5":
                    Console.WriteLine("enter your end year");
                    string EndYear = Console.ReadLine();
                    if (Validation.IsValidYear(EndYear))
                    {
                        newEducation.endDate = EndYear;
                    }
                    else
                    {
                        newEducation.endDate = "";
                        Console.WriteLine("Invalid format, press enter to try again");
                        Console.ReadKey();
                    }
                    return "AddEducationPage";
                case "6":
                    try { 
                        newSql.AddEducation(UserIdPage.newUserProfile.userid, newEducation);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} add a new education detail");
                    }catch(Exception ex) { 
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} cound not add new education detail");
                    }
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
