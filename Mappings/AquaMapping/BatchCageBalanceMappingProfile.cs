using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class BatchCageBalanceMappingProfile : Profile
    {
        public BatchCageBalanceMappingProfile()
        {
            CreateMap<BatchCageBalance, BatchCageBalanceDto>();
            CreateMap<CreateBatchCageBalanceDto, BatchCageBalance>();
            CreateMap<UpdateBatchCageBalanceDto, BatchCageBalance>();
        }
    }
}
