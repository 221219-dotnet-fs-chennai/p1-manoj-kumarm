using UILayer;

namespace TrainerOnline
{
    internal class GoodbyePage : ILayout
    {

        public void Display()
        {
            Console.WriteLine("press [0] - to exit");
        }

        public string UserOption()
        {
            string userinput = Console.ReadLine();
            switch (userinput) {
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("enter a valid command");
                    Console.WriteLine("press enter to try again");
                    Console.ReadKey();
                    return "GoodbyePage";
            }
        }
    }
}
