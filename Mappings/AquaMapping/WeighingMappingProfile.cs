using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class WeighingMappingProfile : Profile
    {
        public WeighingMappingProfile()
        {
            CreateMap<Weighing, WeighingDto>();
            CreateMap<CreateWeighingDto, Weighing>();
            CreateMap<UpdateWeighingDto, Weighing>();
        }
    }
}
