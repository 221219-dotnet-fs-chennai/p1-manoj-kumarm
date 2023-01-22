using DataLayer;
using Serilog;
using UILayer;

namespace TrainerOnline
{
    internal class AddLocationPage : ILayout
    {
        static string constr = File.ReadAllText("../../../Database/cs.txt");
        private static readonly sql newSql = new(constr);
        private static readonly Location newLocation = new();
        public void Display()
        {

            Console.WriteLine($@"-------------------------Add Location-------------------------
    press [1] to enter your zipcode - {newLocation.zipcode}
    press [2] to enter your city name - {newLocation.city}
    press [3] to save changes
    press [b] to go back
    press [0] to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    Console.WriteLine("enter the zipcode");
                    newLocation.zipcode = Console.ReadLine();
                    return "AddLocationPage";
                case "2":
                    Console.WriteLine("enter the city");
                    newLocation.city = Console.ReadLine();
                    return "AddLocationPage";
                case "3":
                    try
                    {
                        newSql.AddNewUserLocation(UserIdPage.newUserProfile.userid, newLocation);
                        Console.WriteLine("saving...");
                        Log.Information($"trainer with id {UserIdPage.newUserProfile.userid} added new location detail");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        Log.Error($"trainer with id {UserIdPage.newUserProfile.userid} could not add location detail");
                    }
                    return "AddLocationPage";
                case "b":
                    return "UserIdPage";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Invalid response, please enter a valid input");
                    Console.WriteLine("Please press \"Enter\" to continue");
                    Console.ReadKey();
                    return "AddLocationPage";
            }
        }
    }
}
