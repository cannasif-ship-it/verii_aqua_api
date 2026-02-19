using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class CageMappingProfile : Profile
    {
        public CageMappingProfile()
        {
            CreateMap<Cage, CageDto>();
            CreateMap<CreateCageDto, Cage>();
            CreateMap<UpdateCageDto, Cage>();
        }
    }
}
