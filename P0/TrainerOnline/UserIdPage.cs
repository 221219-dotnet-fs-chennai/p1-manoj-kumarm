using DataLayer;
using Serilog;
using TrainerOnline;

namespace UILayer
{
    internal class UserIdPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        static string email = "";
        readonly sql newSql = new(constr);
        internal static Register newUserProfile = new();
        public void Display()
        {
            Console.WriteLine("-------------------------Verification/Add/Update/Delete Details-------------------------");
            Console.WriteLine($@"
    -----------Verify your accout-----------
    Press [1] - to enter your email {newUserProfile.email}
    your id is, {newUserProfile.userid}
    Press [2] - to verify
    Press [v] - to view your complete profile

    -----------Update your existing details-----------

    press [3] - to edit and view your personal details 
    press [4] - to update your skill 
    press [5] - to update your location 
    press [6] - to update your education details 
    press [7] - to update your experience details

    -----------Add new details-----------

    press [8] - to add new skill 
    press [9] - to add your location 
    press [10] - to add your education details
    press [11] - to add your experience details

    -----------delete your details-----------

    press [12] - to delete skills
    press [13] - to delete education details
    press [14] - to delete experience details
    Press [15] - to delete your data

    -----------Navigate out-----------

    Press [s] - to go back to sign up page
    Press [l] - to logout
    Press [0] - To exit");
        }

        public string UserOption()
        {
            string input = Console.ReadLine();
            switch (input) {
                case "v":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "ViewCompleteProfilePage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "1":
                    Console.WriteLine("Enter your email for verification [required]");
                    
                    newUserProfile.email = Console.ReadLine();
                    if (!Validation.IsValidEmail(newUserProfile.email))
                    {
                        newUserProfile.email = "";
                        Console.WriteLine("Invalid email");
                        Console.WriteLine("press enter to try again");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                    if (!newSql.CheckEmailExists(newUserProfile.email))
                    {
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} was not able to verify");
                        Console.WriteLine("incorrect email, please press enter to try again else try signing up");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                    Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} was verified");
                    return "UserIdPage";
                case "2":
                    Console.WriteLine("verifying...");
                    newUserProfile.userid = newSql.GetUserId(newUserProfile.email);
                    return "UserIdPage";
                case "3":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "UserDetailsEditPage";
                    }
                    else 
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "4":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "UpdateSkillPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "5":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "UpdateLocationPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "6":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "UpdateEducationPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "7":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "UpdateCompanyPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "8":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "AddSkillPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "9":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "AddLocationPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "10":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "AddEducationPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "11":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "AddCompanyPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "12":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "DeleteSkillsPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "13":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "DeleteEducationPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "14":
                    if (Validation.IsValidId(UserIdPage.newUserProfile.userid.ToString()))
                    {
                        return "DeleteCompanyPage";
                    }
                    else
                    {
                        Console.WriteLine("Please verify your account first, please press enter to continue");
                        Console.ReadKey();
                        return "UserIdPage";
                    }
                case "15":
                    try
                    {
                        Console.WriteLine("enter your id");
                        int userid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Are you sure you want to delete your account permanently?");
                        Console.WriteLine("Press enter key to delete all your data");
                        Console.ReadKey();
                        newSql.DeleteUserData(userid);
                        return "GoodbyePage";
                    }
                    catch(FormatException e) {
                        Console.WriteLine(e.Message);
                    }
                    return "UserIdPage";

                case "s":
                    return "SignUpPage";
                case "l":
                    return "Menu";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");

                    Console.ReadKey();
                    return "UserIdPage";
            }
        }
    }
}
