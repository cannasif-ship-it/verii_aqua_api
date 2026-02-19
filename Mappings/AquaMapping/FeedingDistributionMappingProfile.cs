using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class FeedingDistributionMappingProfile : Profile
    {
        public FeedingDistributionMappingProfile()
        {
            CreateMap<FeedingDistribution, FeedingDistributionDto>();
            CreateMap<CreateFeedingDistributionDto, FeedingDistribution>();
            CreateMap<UpdateFeedingDistributionDto, FeedingDistribution>();
        }
    }
}
