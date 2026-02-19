using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class WeatherTypeMappingProfile : Profile
    {
        public WeatherTypeMappingProfile()
        {
            CreateMap<WeatherType, WeatherTypeDto>();
            CreateMap<CreateWeatherTypeDto, WeatherType>();
            CreateMap<UpdateWeatherTypeDto, WeatherType>();
        }
    }
}
