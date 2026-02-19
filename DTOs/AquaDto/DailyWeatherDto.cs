using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class DailyWeatherDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public DateTime WeatherDate { get; set; }
        public long WeatherTypeId { get; set; }
        public long WeatherSeverityId { get; set; }
        public decimal? TemperatureC { get; set; }
        public decimal? WindKnot { get; set; }
        public string? Note { get; set; }
    }

    public class CreateDailyWeatherDto
    {
        public long ProjectId { get; set; }
        public DateTime WeatherDate { get; set; }
        public long WeatherTypeId { get; set; }
        public long WeatherSeverityId { get; set; }
        public decimal? TemperatureC { get; set; }
        public decimal? WindKnot { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateDailyWeatherDto : CreateDailyWeatherDto
    {
    }
}
