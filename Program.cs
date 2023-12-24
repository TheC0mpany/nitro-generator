using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp71
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            while (true)
            {
                Console.Write("[+] Nitro Generated: ");
                string main = "https://discord.com/billing/partner-promotions/1180231712274387115/";
                string apiUrl = "https://api.discord.gx.games/v1/direct-fulfillment";
                string postData = "{\"partnerUserId\":\"ac432432a77c1e3cef676ac9a0d8a8d982aca36c26abbbe9cd18ac489960b87e\"}";

                var content = new StringContent(postData, Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(apiUrl, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseFromServer = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(main + responseFromServer.Replace("{\"token\":\"", "").Replace("\"}", ""));
                    }
                    else
                    {
                        Console.WriteLine("Error occurred: " + response.StatusCode);
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
