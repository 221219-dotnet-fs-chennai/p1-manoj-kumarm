using System.Net.Http;
using System.Net.Http.Headers;
using LogicLayer;

using System.Text.Json;
namespace UILayer
{
    internal class MenuPage : ILayout
    {
        
        /*public void ApiCalls()
        {
            using var client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:7009/V1/api/Trainers/AddTrainerSignUp");
            *//*Models.TrainerDetail t = new() { 
                Trainerid= 5627,
                Email = "apicall@gmail.com",
                Password = "api@123"
            };
            string path = "postTrainer.json";
            string json = JsonSerializer.Serialize(t);
            File.WriteAllText(path, json);
            var res2 = client.PostAsJsonAsync("https://localhost:7009/V1/api/Trainers/AddTrainerSignUp", File.ReadAllText(path));*//*
            var res = client.GetAsync("https://localhost:7009/V1/api/Trainers/GetAllTrainers");
            res.Wait();
            Console.WriteLine(res.Result.StatusCode);
            var readTask = res.Result.Content.ReadAsAsync<List<Models.TrainerDetail>>();
            readTask.Wait();
            var result = readTask.Result;
            foreach (Models.TrainerDetail item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }*/

        public void Display()
        {
            Console.WriteLine(@$"Main Navigation
    Press [0] - to exit
    Press [1] - to view all trainers
    Press [2] - To sign up
    Press [3] - To login
");
        }

        public string UserChoice()
        {
            string UserInput = Console.ReadLine();
            switch (UserInput)
            {
                case "0":
                    return "MenuPage";
                case "1":
                    return "GetAllTrainerPage";
                case "2":
                    return "AddTrainerSignUpPage";
                case "3":
                    return "TrainerLoginPage";
                // consuming the api
                case "4":
                    //ApiCalls();
                    return "MenuPage";
                default:
                    Console.WriteLine("Invalid input, press enter to try again");
                    Console.ReadKey();
                    return "MenuPage";
            }
        }
    }
}
