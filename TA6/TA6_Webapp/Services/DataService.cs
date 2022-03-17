using System.Collections.Generic;
using TA6_Webapp.Data_Providers;

namespace TA6_Webapp.Services
{
    public class DataService
    {
        public IEnumerable<WeatherForecast>? GetForecasts(string uri)
        {
            return new WeatherProvider().GetWeatherForecasts(uri);
        }
    }
}