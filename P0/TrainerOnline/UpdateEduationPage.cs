using DataLayer;
using Serilog;
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
            if (list.Count != 0) {
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
            }
            else
            {
                Console.WriteLine("Please add the education details first to update them, press b to go back");
            }

            Console.WriteLine($@"    
    Press [1] - to update institute name - {newName}
    Press [2] - to update degree name - {newDegree}
    Press [3] - to update gpa [eg: 8.2, 9.0, 5.6] - {newGpa}
    Press [4] - to update start year [format: yyyy] - {newStartDate}
    Press [5] - to update end year [format: yyyy] - {NewEndDate}
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
                    string OldGpa = Console.ReadLine();
                    if (Validation.IsValidGpa(OldGpa)) {
                        oldGpa = OldGpa;
                    }
                    else
                    {
                        oldGpa = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    string NewGpa = Console.ReadLine();
                    if (Validation.IsValidGpa(NewGpa)) {
                        newGpa = NewGpa;
                    }
                    else
                    {
                        newGpa = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "UpdateEducationPage";
                case "4":
                    Console.WriteLine("enter your old start date");
                    string OldStartYear = Console.ReadLine();
                    if (Validation.IsValidYear(OldStartYear)) {
                        oldStartDate = OldStartYear;
                    }
                    else
                    {
                        oldStartDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter your new start date");
                    string NewStartYear = Console.ReadLine();
                    if (Validation.IsValidYear(NewStartYear)) { 
                        newStartDate = NewStartYear;
                    }
                    else
                    {
                        newStartDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "UpdateEducationPage";
                case "5":
                    Console.WriteLine("enter your old end date");
                    string OldEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(OldEndYear)) {
                        oldEndDate = OldEndYear;
                    }
                    else
                    {
                        oldEndDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    Console.WriteLine("enter your new end date");
                    string NewEndYear = Console.ReadLine();
                    if (Validation.IsValidYear(NewEndYear)) { 
                        NewEndDate = NewEndYear;    
                    }
                    else
                    {
                        NewEndDate = "";
                        Console.WriteLine("Invalid format, please press enter to try again");
                        Console.ReadKey();
                    }
                    return "UpdateEducationPage";
                case "6":
                    try
                    {
                        newSql.UpdateEducation(UserIdPage.newUserProfile.userid, oldName, newName, oldDegree, newDegree, oldGpa, newGpa, oldStartDate, newStartDate, oldEndDate, NewEndDate);
                        Console.WriteLine("saving...");
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} updated education detail");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update education detail");
                    }
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
