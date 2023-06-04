using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Services;

namespace WeatherApp.Pages.City
{
    public class DeleteModel : PageModel
    {
        private DbService _dbService;

        public DeleteModel(DbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            int id = int.Parse(Request.Query["CityId"]);
            await _dbService.DeleteFromDb(id);
            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }
}
