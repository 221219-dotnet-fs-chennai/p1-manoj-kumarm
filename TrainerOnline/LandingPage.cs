using UILayer;
namespace TrainerOnline
{
    internal class LandingPage : ILayout
    {
        public void Display()
        {
            try {
                Console.WriteLine(@"                                                            =======================================================     
                                                                                  MENTOR ONLINE
                                                            =======================================================     
Please press any key to get started...");
            }
            catch (IOException e) {
                throw new Exception(e.Message);
            }
        }

        public string UserOption()
        {
            try {
                switch (Console.ReadKey()) {
                    case ConsoleKeyInfo:
                        return "Menu";
                }
            }
            catch (InvalidOperationException e) { 
                throw new Exception(e.Message); 
            }
        }
    }
}
