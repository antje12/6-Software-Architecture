using System;
using System.ComponentModel.DataAnnotations;

namespace TA6_API;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    
    /// <summary>
    /// The City of the result
    /// </summary>
    [Required]
    public string City { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
