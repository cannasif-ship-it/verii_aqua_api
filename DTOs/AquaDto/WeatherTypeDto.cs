using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class WeatherTypeDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CreateWeatherTypeDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class UpdateWeatherTypeDto : CreateWeatherTypeDto
    {
    }
}
