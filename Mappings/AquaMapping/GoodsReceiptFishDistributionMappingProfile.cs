using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class GoodsReceiptFishDistributionMappingProfile : Profile
    {
        public GoodsReceiptFishDistributionMappingProfile()
        {
            CreateMap<GoodsReceiptFishDistribution, GoodsReceiptFishDistributionDto>();
            CreateMap<CreateGoodsReceiptFishDistributionDto, GoodsReceiptFishDistribution>();
            CreateMap<UpdateGoodsReceiptFishDistributionDto, GoodsReceiptFishDistribution>();
        }
    }
}
