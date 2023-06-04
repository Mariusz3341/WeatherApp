using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class DbService
    {
        private readonly CityWeatherDbContext _context;
        public DbService(CityWeatherDbContext context)
        {
            _context = context;
        }

        public async Task AddToDb(CityWeather cityWeather)
        {
            bool exists = _context.Cities.Any(obj => obj.CityName == cityWeather.CityName);

            if (exists)
            {
                var obj = _context.Cities.FirstOrDefault(obj => obj.CityName == cityWeather.CityName);
                obj.Country = cityWeather.Country;
                obj.Temp_C = cityWeather.Temp_C;
                obj.Temp_F = cityWeather.Temp_F;
                obj.Info = cityWeather.Info;
                obj.LastUpdate = cityWeather.LastUpdate;
                _context.Cities.Update(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Cities.Add(cityWeather);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<CityWeather>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task DeleteFromDb(int id)
        {
            var objectToRemove = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(objectToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<CityWeather?> FindById(int id)
        {
            var obj = await _context.Cities.FindAsync(id);
            return obj;
        }
        public async Task Update(CityWeather cityWeatherToEdit)
        {   
            cityWeatherToEdit.LastUpdate = DateTime.Now;
            _context.Cities.Update(cityWeatherToEdit);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CityWeather>> GetAllSorted()
        {
            List<CityWeather>? cities = null;
            cities = await _context.Cities.OrderBy(item => item.CityName).ToListAsync();
            return cities;
        }

    }
}
