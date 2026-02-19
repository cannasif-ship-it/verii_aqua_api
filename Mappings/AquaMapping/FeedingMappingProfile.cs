using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class FeedingMappingProfile : Profile
    {
        public FeedingMappingProfile()
        {
            CreateMap<Feeding, FeedingDto>()
                .ForMember(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectCode : null))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectName : null));
            CreateMap<CreateFeedingDto, Feeding>();
            CreateMap<UpdateFeedingDto, Feeding>();
        }
    }
}
