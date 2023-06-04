using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using WeatherApp.Data;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {private int asgf = 0;
        private readonly ILogger<IndexModel> _logger;
        private ApiService _apiService;
        public DbService _dbService;
        public IList<CityWeather> cities { get; set; } = default!;
        [BindProperty]
        public string Cityname { get; set; }

        public IndexModel(ILogger<IndexModel> logger,ApiService apiService, DbService dbService)
        {
            _logger = logger;
            _apiService = apiService;
            _dbService = dbService;
        }


        public async Task OnGetAsync()
        {
            Response.Cookies.Append("ValidationCookie", "");
            //cities = await _dbService.GetAll();
            cities = await _dbService.GetAllSorted();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CityWeather? cityWeather = await _apiService.FetchFromApi(Cityname);
            if (cityWeather != null)
            {
                await _dbService.AddToDb(cityWeather);
            } 
            else
            {
                Response.Cookies.Append("ValidationCookie", "Wrong city or country name");
            }
            return RedirectToPage();
        }
    }
}