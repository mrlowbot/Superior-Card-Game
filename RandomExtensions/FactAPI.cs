using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardGame
{
    public class FactAPI
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetRandomFactAsync()
        {
            int randomNumber = new Random().Next(1, 100);
            string url = $"http://numbersapi.com/{randomNumber}";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }

            return "Failed to fetch a random fact.";
        }
    }
}
