using Lab_1._4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
namespace Asynchronous
{
    class Program
    {
        public static List<User> users = new List<User>();
        public static HttpClient client = new HttpClient();
        public static async Task<List<User>> getUsers()
        {
            List<User> result = new List<User>();
            try
            {
                HttpResponseMessage response = await
               client.GetAsync("https://6643265f3c01a059ea21b1b6.mockapi.io/Urer");
                string data = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<User>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not load the data!\nError: {ex.Message}");
            }
        }
        public static void showUsers()
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            try
            {
                //Get Data
                users = getUsers().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load False!", ex.Message);
            }
            //Show Data
            showUsers();
            Console.WriteLine("Load Success!");
        }
    }
}