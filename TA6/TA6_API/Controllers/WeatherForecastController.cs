using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TA6_API.Controllers;

/// <summary>
/// Controller for Weather Forecast Information
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get Weather Forecast Information
    /// </summary>
    /// <param name="city">The city</param>
    /// <param name="date">The from date</param>
    /// <param name="span">The amount to return</param>
    /// <returns></returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IEnumerable<WeatherForecast> Get([Required] string city, DateTime? date, int span)
    {
        return Enumerable.Range(1, span)
            .Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            City = city,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .Where(x => x.Date > (date ?? DateTime.Now))
        .ToArray();
    }
}
