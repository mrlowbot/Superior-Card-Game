using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace CardGame
{
    public class API
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetRandomJokeAsync()
        {
            string url = "https://v2.jokeapi.dev/joke/Any";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(content);

                if (json.ContainsKey("joke"))
                {
                    return json["joke"].ToString();
                }
                else if (json.ContainsKey("setup") && json.ContainsKey("delivery"))
                {
                    return $"{json["setup"]} {json["delivery"]}";
                }
            }

            return "Failed to fetch a random joke.";
        }
    }
}
