using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class WeighingLineMappingProfile : Profile
    {
        public WeighingLineMappingProfile()
        {
            CreateMap<WeighingLine, WeighingLineDto>();
            CreateMap<CreateWeighingLineDto, WeighingLine>();
            CreateMap<UpdateWeighingLineDto, WeighingLine>();
        }
    }
}
