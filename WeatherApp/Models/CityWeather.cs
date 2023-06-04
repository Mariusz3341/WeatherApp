using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class CityWeather
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "City")]
        public string CityName { get; set; } = null!;

        [Display(Name = "Country")]
        public string Country { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        [Range(-100, 100, ErrorMessage = "Temperature value must be between -100 and 100")]
        [Display(Name = "Temperature (Celsius)")]
        public decimal Temp_C { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        [Range(-100, 100, ErrorMessage = "Temperature value must be between -100 and 100")]
        [Display(Name = "Temperature (Fahrenheit)")]
        public decimal Temp_F { get; set; }

        [Display(Name = "Information")]
        public string? Info { get; set; }

        [Display(Name = "Last update")]
        public DateTime LastUpdate { get; set; }
    }
}
