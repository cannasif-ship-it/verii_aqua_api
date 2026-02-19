using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class MortalityLineMappingProfile : Profile
    {
        public MortalityLineMappingProfile()
        {
            CreateMap<MortalityLine, MortalityLineDto>();
            CreateMap<CreateMortalityLineDto, MortalityLine>();
            CreateMap<UpdateMortalityLineDto, MortalityLine>();
        }
    }
}
