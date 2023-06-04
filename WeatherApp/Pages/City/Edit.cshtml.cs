using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Pages.City
{
    public class EditModel : PageModel
    {
        private DbService _dbService;

        [BindProperty]
        public CityWeather cityWeatherToEdit { get; set; }
        public EditModel(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task OnGetAsync()
        {
            int id = int.Parse(Request.Query["CityId"]);
            cityWeatherToEdit = await _dbService.FindById(id);
        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _dbService.Update(cityWeatherToEdit);
            return RedirectToPage("/Index");
        }
    }
}
