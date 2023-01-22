using DataLayer;
using TrainerOnline;
using System.Collections.Generic;
using Serilog;

namespace UILayer
{
    internal class UserDetailsEditPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        internal static UpdateDetails userUpdate = new();
        private readonly sql newSql = new sql(constr);
        public void Display()
        {
            try
            {
                Console.WriteLine("-------------------------User Profile-------------------------");
                Console.WriteLine($@"
    Edit your profile

    press [1] - to edit Fullname: {userUpdate.fullname}
    press [2] - to edit Phone: {userUpdate.phone}
    press [3] - to edit Website: {userUpdate.website}
    press [4] - to edit About me: {userUpdate.aboutme}
    press [5] - to edit Gender: {userUpdate.gender}
    press [6] - to enter to save the changes
    press [0] - to exit
    press [b] - to go back");
            }
            catch(IOException e) { 
                Console.WriteLine(e.Message);
            }
        }
        public string UserOption()
        {

            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Enter your full name [required]");
                    userUpdate.fullname = Console.ReadLine();
                    return "UserDetailsEditPage";
                case "2":
                    Console.WriteLine("Enter your phone number [must contain 10 digits]");
                    userUpdate.phone = Console.ReadLine();
                    return "UserDetailsEditPage";
                case "3":
                    Console.WriteLine("Enter your website url");
                    userUpdate.website = Console.ReadLine();
                    return "UserDetailsEditPage";
                case "4":
                    Console.WriteLine("Tell more about yourself");
                    userUpdate.aboutme = Console.ReadLine();
                    return "UserDetailsEditPage";
                case "5":
                    Console.WriteLine("Enter your gender");
                    userUpdate.gender = Console.ReadLine();
                    return "UserDetailsEditPage";
                case "6":
                    try
                    {
                        Console.WriteLine("saving changes...");    
                        newSql.AddOtherDetails(UserIdPage.newUserProfile.userid, userUpdate);
                        Log.Information($"trainer with id: {UserIdPage.newUserProfile.userid} updated their personal details");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id: {UserIdPage.newUserProfile.userid} could not update their personal details");

                    }
                    return "UserDetailsEditPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "UserDetailsEditPage";
            }
        }
    }
}
