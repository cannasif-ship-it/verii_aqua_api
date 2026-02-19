using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class BatchMovementMappingProfile : Profile
    {
        public BatchMovementMappingProfile()
        {
            CreateMap<BatchMovement, BatchMovementDto>();
            CreateMap<CreateBatchMovementDto, BatchMovement>();
            CreateMap<UpdateBatchMovementDto, BatchMovement>();
        }
    }
}
