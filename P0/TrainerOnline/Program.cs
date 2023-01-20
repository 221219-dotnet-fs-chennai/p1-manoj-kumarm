using UILayer;
using Serilog;
using TrainerOnline;


Console.Title = "Mentor Online";
string newpath = "../../../Database/logs.txt";
if(!File.Exists(newpath)) File.Create(newpath);
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(newpath, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit:true)
    .CreateLogger();


bool repeat = true;
ILayout newMenu = new LandingPage();
while (repeat) {
    Console.Clear();
    newMenu.Display();
    string option = newMenu.UserOption();
    switch (option) {
        case "LandingPage":
            Log.Information("Displaying landing page to the user");
            newMenu = new LandingPage();
            break;
        case "Menu":
            Log.Information("Displaying main page to the user");
            newMenu = new Menu();
            break;
        case "SignUpPage":
            Log.Information("Displaying sign page to the user");
            newMenu = new SignUpPage();
            break;
        case "LoginPage":
            Log.Information("Displying login page to the user");
            newMenu = new LoginPage();
            break;
        case "UserIdPage":
            Log.Information("Displaying user id page to the user");
            newMenu = new UserIdPage();
            break;
        case "UserDetailsEditPage":
            Log.Information("Displaying profile page to the user");
            newMenu = new UserDetailsEditPage();
            break;
        case "AddSkillPage":
            Log.Information("Displaying update/add skills page to the user");
            newMenu = new AddSkillPage();
            break;
        case "UpdateSkillPage":
            Log.Information("Displaying update skills page to the user");
            newMenu = new UpdateSkillPage();
            break;
        case "AddLocationPage":
            Log.Information("Displaying add location page to the user");
            newMenu = new AddLocationPage();
            break;
        case "UpdateLocationPage":
            Log.Information("Displaying update location page to the user");
            newMenu = new UpdateLocationPage();
            break;
        case "AddEducationPage":
            Log.Information("Displaying add education details page to the user");
            newMenu = new AddEducationPage();
            break;
        case "UpdateEducationPage":
            Log.Information("Displaying update education details page to the user");
            newMenu = new UpdateEduationPage();
            break;
        case "AddCompanyPage":
            Log.Information("Displaying add company details page to the user");
            newMenu = new AddCompanyPage();
            break;
        case "UpdateCompanyPage":
            Log.Information("Displaying update company details page to the user");
            newMenu = new UpdateCompanyPage();
            break;
        case "DeleteSkillsPage":
            Log.Information("Displaying delete skill page to the user");
            newMenu = new DeleteSkillsPage();
            break;
        case "DeleteCompanyPage":
            Log.Information("Displaying delete skill page to the user");
            newMenu = new DeleteCompanyPage();
            break;
        case "DeleteEducationPage":
            Log.Information("Displaying delete skill page to the user");
            newMenu = new DeleteEducationPage();
            break;
        case "GoodbyePage":
            Log.Information("your data has been deleted...");
            newMenu = new GoodbyePage();
            break;
        case "Exit":
            Log.Information("User exited the application");
            Log.CloseAndFlush();
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does'nt exist");
            Console.WriteLine("Please press enter to continue");
            Console.ReadKey();
            break;
    }
}


