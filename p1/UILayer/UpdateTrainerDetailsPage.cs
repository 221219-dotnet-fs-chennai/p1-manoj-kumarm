using LogicLayer;

namespace UILayer
{
    internal class UpdateTrainerDetailsPage : ILayout
    {
        private static ILogic logic = new Logic();
        private static Models.TrainerDetail trainer = new();
        public void Display()
        {
            Console.WriteLine(@$"
    Press [0] to exit
    Press [1] to enter fullname  -  {trainer.Fullname}
    Press [2] to enter phone     -  {trainer.Phone}
    Press [3] to enter website   -  {trainer.Website}
    Press [4] to enter aboutme   -  {trainer.Aboutme}
    Press [5] to enter age       -  {trainer.Age}
    Press [6] to enter gender    -  {trainer.Gender}
    Press [7] to enter save changes
    Press [b] to go back
");
        }

        public string UserChoice()
        {
            var tra1 = new DataFluentApi.Entities.TrainerDetail();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "b":
                    return "EditAllPage";
                case "1":
                    Console.WriteLine("enter your full name[required]");
                    trainer.Fullname = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "2":
                    Console.WriteLine("enter your phone[10 digit]");
                    trainer.Phone = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "3":
                    Console.WriteLine("enter your website url");
                    trainer.Website = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "4":
                    Console.WriteLine("enter your about me");
                    trainer.Aboutme = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "5":
                    Console.WriteLine("enter your age");
                    trainer.Age = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "6":
                    Console.WriteLine("enter your gender");
                    trainer.Gender = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "7":
                    trainer.Trainerid = EditAllPage.newtrainer.Trainerid;
                    logic.UpdateTrainerDetails(trainer);
                    Console.WriteLine("updating...");
                    Console.ReadKey();
                    return "UpdateTrainerDetailsPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "UpdateTrainerDetailsPage";
            }
        }
    }
}
