using DotNetEnv;
using Newtonsoft.Json;

namespace CardGame
{
    public class NasaAPI
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string? apiKey;
        private const string apiUrl = "https://api.nasa.gov/planetary/apod";

        static NasaAPI()
        {
            Env.Load(".env.local");
            apiKey = Environment.GetEnvironmentVariable("NASA_API_KEY");
        }


        public async Task<string> GetAstronomyPictureOfTheDayAsync()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return "API key not found. Please get an API key from https://api.nasa.gov/ and set it in the NasaAPI class.";
            }

            string url = $"{apiUrl}?api_key={apiKey}";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ApodResponse apod = JsonConvert.DeserializeObject<ApodResponse>(content);
                return $"Title: {apod.Title}\nDate: {apod.Date}\nExplanation: {apod.Explanation}\nURL: {apod.Url}\n";
            }

            return "Failed to fetch Astronomy Picture of the Day.";
        }

        public class ApodResponse
        {
            [JsonProperty("date")]
            public string Date { get; set; }

            [JsonProperty("explanation")]
            public string Explanation { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
