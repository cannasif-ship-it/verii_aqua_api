using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class FishBatchMappingProfile : Profile
    {
        public FishBatchMappingProfile()
        {
            CreateMap<FishBatch, FishBatchDto>();
            CreateMap<CreateFishBatchDto, FishBatch>();
            CreateMap<UpdateFishBatchDto, FishBatch>();
        }
    }
}
