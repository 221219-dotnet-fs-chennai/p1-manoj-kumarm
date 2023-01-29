namespace UILayer
{
    internal class UIUtility
    {
        internal static string TryAgainForEditAllPage()
        {
            Console.WriteLine("incorrect email, please press <t> to try again else try signing up by pressing <s>");
            string ip = Console.ReadLine();
            switch (ip)
            {
                case "t":
                    return "EditAllPage";
                case "s":
                    return "AddTrainerSignUpPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "EditAllPage";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string TryAgainForLoginPage()
        {
            Console.WriteLine("incorrect email, please press <t> to try again else try signing up by pressing <s>");
            string ip = Console.ReadLine();
            switch (ip)
            {
                case "t":
                    return "TrainerLoginPage";
                case "s":
                    return "AddTrainerSignUpPage";
                default:
                    Console.WriteLine("invalid reponse, press enter to continue");
                    Console.ReadKey();
                    return "TrainerLoginPage";
            }
        }
    }
}
