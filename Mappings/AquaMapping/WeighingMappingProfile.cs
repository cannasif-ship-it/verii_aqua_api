using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class WeighingMappingProfile : Profile
    {
        public WeighingMappingProfile()
        {
            CreateMap<Weighing, WeighingDto>()
                .ForMember(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectCode : null))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectName : null));
            CreateMap<CreateWeighingDto, Weighing>();
            CreateMap<UpdateWeighingDto, Weighing>();
        }
    }
}
