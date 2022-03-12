using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TA3.DTOs;
using TA3.Services;

namespace TA3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataService _dataService;
        public IEnumerable<ProductDTO> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, DataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public void OnGet()
        {
            Products = _dataService.GetProducts();
        }
    }
}