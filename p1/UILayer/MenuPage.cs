using System.Net.Http;
using System.Net.Http.Headers;
using LogicLayer;

using System.Text.Json;
namespace UILayer
{
    internal class MenuPage : ILayout
    {

        public async void ApiCalls()
        {
            using var client = new HttpClient();
            /*using var client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:7009/V1/api/Trainers/AddTrainerSignUp");
            Models.TrainerDetail t = new()
            {
                Trainerid = 5627,
                Email = "apicall@gmail.com",
                Password = "api@123"
            };
            string path = "postTrainer.json";
            string json = JsonSerializer.Serialize(t);
            File.WriteAllText(path, json);
            Console.WriteLine(File.ReadAllText(path));*/
            //var res2 = client.PostAsJsonAsync("https://localhost:7009/V1/api/Trainers/AddTrainerSignUp", File.ReadAllText(path));

            //POST
            /*Models.TrainerDetail t = new();
            t.Email = "restapi2@gmail.com";
            t.Password = "Pass@123";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(t);
            var data = new System.Net.Http.StringContent(json, encoding: System.Text.Encoding.UTF8, "application/json");
            var url = "https://localhost:7009/V1/api/Trainers/AddTrainerSignUp";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            string responseText = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseText);*/

            //GET
            var res = client.GetAsync($"https://localhost:7009/V1/api/Users/by");
            res.Wait();
            Console.WriteLine(res.Result.StatusCode);
            var readTask = res.Result.Content.ReadAsAsync<List<Models.All>>();
            readTask.Wait();
            var result = readTask.Result;
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

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
                    ApiCalls();
                    return "MenuPage";
                default:
                    Console.WriteLine("Invalid input, press enter to try again");
                    Console.ReadKey();
                    return "MenuPage";
            }
        }
    }
}
