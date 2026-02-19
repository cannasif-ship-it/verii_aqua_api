using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class WeatherSeverityMappingProfile : Profile
    {
        public WeatherSeverityMappingProfile()
        {
            CreateMap<WeatherSeverity, WeatherSeverityDto>();
            CreateMap<CreateWeatherSeverityDto, WeatherSeverity>();
            CreateMap<UpdateWeatherSeverityDto, WeatherSeverity>();
        }
    }
}
