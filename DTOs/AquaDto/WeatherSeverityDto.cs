using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class WeatherSeverityDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class CreateWeatherSeverityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class UpdateWeatherSeverityDto : CreateWeatherSeverityDto
    {
    }
}
