using UILayer;

bool repeat = true;
ILayout layout = new MenuPage();
while (repeat)
{
    Console.Clear();
    layout.Display();
    string redirect = layout.UserChoice();
    switch (redirect)
    {
        case "Exit":
            repeat = false;
            break;
        case "MenuPage":
            layout = new MenuPage();
            break;
        case "GetAllTrainerPage":
            layout = new GetAllTrainersPage();
            break;
        case "AddTrainerSignUpPage":
            layout = new AddTrainerSignUpPage();
            break;
        case "TrainerLoginPage":
            layout = new TrainerLoginPage();
            break;
        case "UpdateTrainerDetailsPage":
            layout = new UpdateTrainerDetailsPage();
            break;
        case "UpdateSkillPage":
            layout = new UpdateSkillPage();
            break;
        case "AddTrainerSkillsPage":
            layout = new AddTrainerSkillsPage();
            break;
        case "DeleteSkillsPage":
            layout = new DeleteSkillsPage();
            break;
        case "EditAllPage":
            layout = new EditAllPage();
            break;
        default:
            Console.WriteLine("Page not found...\nPress enter to continue");
            break;
    }
}