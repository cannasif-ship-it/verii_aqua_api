using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class MortalityMappingProfile : Profile
    {
        public MortalityMappingProfile()
        {
            CreateMap<Mortality, MortalityDto>();
            CreateMap<CreateMortalityDto, Mortality>();
            CreateMap<UpdateMortalityDto, Mortality>();
        }
    }
}
