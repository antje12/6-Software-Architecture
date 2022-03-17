using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TA6_Webapp;
using TA6_Webapp.Services;

namespace TA6_Webapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DataService _dataService;
    private readonly TemperatureStatsService _temperatureStatsService;
    
    public double mean;
    public double variance;
    public double standardDeviation;
    
    public IEnumerable<WeatherForecast> Forecasts { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, DataService dataService, TemperatureStatsService temperatureStatsService)
    {
        _logger = logger;
        _dataService = dataService;
        _temperatureStatsService = temperatureStatsService;
    }

    public void OnGet()
    {
        Forecasts = _dataService.GetForecasts("https://localhost:7043/WeatherForecast?city=Odense&span=10");
        
        if (Forecasts == null) return;
        mean = _temperatureStatsService.GetMean(Forecasts);
        variance = _temperatureStatsService.GetVariance(Forecasts);
        standardDeviation = _temperatureStatsService.GetStandardDeviation(Forecasts);
    }
}
