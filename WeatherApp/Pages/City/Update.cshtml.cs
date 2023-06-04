using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Pages.City
{
    public class UpdateModel : PageModel
    {
        private ApiService _apiService;
        private DbService _dbService;

        public UpdateModel(ApiService apiService, DbService dbService)
        {
            _apiService = apiService;
            _dbService = dbService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int id = int.Parse(Request.Query["CityId"]);
            CityWeather? cityWeatherToUpdate = await _dbService.FindById(id);
            await _apiService.Update(cityWeatherToUpdate);
            await _dbService.Update(cityWeatherToUpdate);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
