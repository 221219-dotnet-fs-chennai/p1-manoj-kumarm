using Models;

namespace UILayer
{
    internal class UpdateTrainerDetailsPage : ILayout
    {
        private static DataFluentApi.Entities.TrainerDetail trainer = new();
        private static IRepo<DataFluentApi.Entities.TrainerDetail> _repo = new DataFluentApi.EFRepo();
        public void Display()
        {
            Console.WriteLine(@$"
    Press [0] to exit
    Press [1] to enter fullname  -  {trainer.Fullname}
    Press [2] to enter phone     -  {trainer.Phone}
    Press [3] to enter website   -  {trainer.Website}
    Press [4] to enter aboutme   -  {trainer.Aboutme}
    Press [5] to enter age       -  {trainer.Age}
    Press [6] to enter save changes
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
                    return "MenuPage";
                case "1":
                    Console.WriteLine("enter your full name[required]");
                    trainer.Fullname = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "2":
                    Console.WriteLine("enter your phone[10 digit]");
                    trainer.Phone = Console.ReadLine();
                    return "AddTrainerSignUpPage";
                case "3":
                    Console.WriteLine("enter your website url");
                    trainer.Website = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "4":
                    Console.WriteLine("enter your about me");
                    trainer.Aboutme = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "5":
                    Console.WriteLine("enter your about me");
                    trainer.Age = Console.ReadLine();
                    return "UpdateTrainerDetailsPage";
                case "6":
                    Console.WriteLine("ladn");
                    _repo.Update(trainer);
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
