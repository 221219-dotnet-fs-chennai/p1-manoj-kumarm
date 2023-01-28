using DataFluentApi;
using LogicLayer;


namespace UILayer
{
    internal class EditAllPage : ILayout
    {
        ILogic logic = new Logic();
        private static DataFluentApi.Entities.TrainerDetail trainer = new();
        public void Display()
        {
            Console.WriteLine("-------------------------Verification/Add/Update/Delete Details-------------------------");
            Console.WriteLine($@"
    -----------Verify your accout-----------
    Press [1] - to enter your email - {trainer.Email}
    your id is, {trainer.Trainerid}
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

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter your email for verification [required]");
                    trainer.Email = Console.ReadLine();
                    if (!logic.CheckEmailExists(trainer.Email))
                    {
                        Console.WriteLine("incorrect email, please press enter to try again else try signing up");
                        Console.ReadKey();
                        return "EditAllPage";
                    }
                    Console.WriteLine("email exists");
                    Console.ReadKey();
                    return "EditAllPage";
                case "2":
                    trainer.Trainerid = logic.GetTrainerIdByEmail(trainer.Email);
                    return "EditAllPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "EditAllPage";
            }
        }
    }
}
