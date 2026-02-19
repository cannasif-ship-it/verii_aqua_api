using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class DailyWeatherMappingProfile : Profile
    {
        public DailyWeatherMappingProfile()
        {
            CreateMap<DailyWeather, DailyWeatherDto>();
            CreateMap<CreateDailyWeatherDto, DailyWeather>();
            CreateMap<UpdateDailyWeatherDto, DailyWeather>();
        }
    }
}
