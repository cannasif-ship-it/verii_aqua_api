using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class FeedingLineMappingProfile : Profile
    {
        public FeedingLineMappingProfile()
        {
            CreateMap<FeedingLine, FeedingLineDto>();
            CreateMap<CreateFeedingLineDto, FeedingLine>();
            CreateMap<UpdateFeedingLineDto, FeedingLine>();
        }
    }
}
