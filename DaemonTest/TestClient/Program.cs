using IdentityModel.Client;
using System.Net.Http.Headers;

namespace TestClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //TODO get token from azure discovery open id config
            //var token = RequestTokenAsync();

            var apiClient = new HttpClient();
            
            //hardcoding access token 
            var accessToken = "RueGTRVrDBBfTZu0_nHKmK8Zl9uk_S2ltgrOU3k4DnjKWDGOnmZsBxLSvil-MiJ5wRFUf7URsxmXpR7s6UGAFQgw";

            apiClient.SetBearerToken(accessToken);

            //https://localhost:7000/WeatherForecast/GetClaims
            //https://localhost:7000/WeatherForecast/GetWeatherForecast
            var response = await apiClient.GetAsync("https://localhost:7000/WeatherForecast/GetWeatherForecast");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }

            Console.ReadLine();
        }

       
    }
}