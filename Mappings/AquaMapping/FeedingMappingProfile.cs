using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class FeedingMappingProfile : Profile
    {
        public FeedingMappingProfile()
        {
            CreateMap<Feeding, FeedingDto>();
            CreateMap<CreateFeedingDto, Feeding>();
            CreateMap<UpdateFeedingDto, Feeding>();
        }
    }
}
