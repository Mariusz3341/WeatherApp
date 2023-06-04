using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ApiService
    {
        private string ApiKey { get; set; }

        public ApiService()
        {
            ApiKey = "6c86bfc8d99f46ed9dd135623233105";
        }

        public async Task<CityWeather?> FetchFromApi(string CityName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=" + ApiKey + "&q=" + CityName + "&aqi=no");
            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            string resp = await response.Content.ReadAsStringAsync();
            CityWeather cityWeather = new CityWeather();

            JsonDocument document = JsonDocument.Parse(resp);
            JsonElement root = document.RootElement;
            cityWeather.CityName = root.GetProperty("location").GetProperty("name").GetString();
            cityWeather.Country = root.GetProperty("location").GetProperty("country").GetString();
            cityWeather.Temp_C = root.GetProperty("current").GetProperty("temp_c").GetDecimal();
            cityWeather.Temp_F = root.GetProperty("current").GetProperty("temp_f").GetDecimal();
            cityWeather.Info = root.GetProperty("current").GetProperty("condition").GetProperty("text").GetString();
            cityWeather.LastUpdate = DateTime.Now;

            return cityWeather;
        }

        public async Task<CityWeather?> Update(CityWeather? cityWeatherToUpdate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=" + ApiKey + "&q=" + cityWeatherToUpdate.CityName + "&aqi=no");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string resp = await response.Content.ReadAsStringAsync();
            //CityWeather cityWeather = new CityWeather();

            JsonDocument document = JsonDocument.Parse(resp);
            JsonElement root = document.RootElement;
            cityWeatherToUpdate.CityName = root.GetProperty("location").GetProperty("name").GetString();
            cityWeatherToUpdate.Country = root.GetProperty("location").GetProperty("country").GetString();
            cityWeatherToUpdate.Temp_C = root.GetProperty("current").GetProperty("temp_c").GetDecimal();
            cityWeatherToUpdate.Temp_F = root.GetProperty("current").GetProperty("temp_f").GetDecimal();
            cityWeatherToUpdate.Info = root.GetProperty("current").GetProperty("condition").GetProperty("text").GetString();
            cityWeatherToUpdate.LastUpdate = DateTime.Now;

            return cityWeatherToUpdate;
        }
    }
}
