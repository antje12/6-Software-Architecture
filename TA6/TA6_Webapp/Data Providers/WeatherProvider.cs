using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TA6_Webapp.Data_Providers
{
    public class WeatherProvider
    {
        private static readonly HttpClient Client = new HttpClient();
    
        // In order to display the forecasts on our page, we need to get them from the API
        public IEnumerable<WeatherForecast>? GetWeatherForecasts(string uri)
        {
            var t = WebApiClient(uri, Client);
            if (t != null) return new List<WeatherForecast>(t.Result);
            return null;
        }
    
        private static async Task<WeatherForecast[]>? WebApiClient(string uri, HttpClient httpClient)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            
            using var httpResponse = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            try
            {
                return await httpResponse.Content.ReadAsAsync<WeatherForecast[]>();
            }
            catch // Could be ArgumentNullException or UnsupportedMediaTypeException
            {
                Console.WriteLine("HTTP Response was invalid or could not be deserialized.");
            }

            return null;
        }
    }
}