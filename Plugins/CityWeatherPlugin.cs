using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SKReactor.Plugins
{
    // Native function: native code with custom logic
    public class CityWeatherPlugin
    {
        HttpClient client = new HttpClient();

        [KernelFunction]
        [Description("Describes the current weather of a city in JSON format")]
        public async Task<string> GetWeather(
            [Description("The name of the city ")] string city)
        {
            var key = "";
            var query = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}";

            var result = await client.GetAsync(query);

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return "Error, the weather of the city is not available at this moment";
        }
    }
}
