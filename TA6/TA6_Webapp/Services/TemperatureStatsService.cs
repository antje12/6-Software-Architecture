using System;
using System.Collections.Generic;

namespace TA6_Webapp.Services
{
    public class TemperatureStatsService
    {
        public List<double> GetTempValues(IEnumerable<WeatherForecast> forecasts)
        {
            var values = new List<double>();
            foreach (var f in forecasts)
            {
                values.Add(f.TemperatureC);
            }

            return values;
        }
        public double GetMean(IEnumerable<WeatherForecast> forecasts)
        {
            var values = GetTempValues(forecasts);
        
            double s = 0;
 
            foreach (var t in values)
            {
                s += t;
            }
 
            return s / (values.Count);
        }
 
        public double GetVariance(IEnumerable<WeatherForecast> forecasts)
        {
            var values = GetTempValues(forecasts);
        
            double variance = 0;
 
            foreach (var t in values)
            {
                variance += Math.Pow(t - GetMean(forecasts), 2);
            }

            return variance / values.Count;
        }
 
        public double GetStandardDeviation(IEnumerable<WeatherForecast> forecasts)
        {
            return Math.Sqrt(GetVariance(forecasts));
        }
    }
}