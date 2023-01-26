namespace UILayer
{
    internal interface ILayout
    {
        //void UserOption(string option);
        //void ShowMenu();
        //void WelcomePage();
        //void RegistrationMenu();
        //void ProfileEditMenu();
        //void LogoutMenu();
        /// <summary>
        /// Implements UI
        /// </summary>
        void Display();
        /// <summary>
        /// Implements to fetch user response
        /// </summary>
        /// <returns>user response as string</returns>
        string UserOption();
    }
}
