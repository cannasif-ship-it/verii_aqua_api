using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class GoodsReceiptMappingProfile : Profile
    {
        public GoodsReceiptMappingProfile()
        {
            CreateMap<GoodsReceipt, GoodsReceiptDto>();
            CreateMap<CreateGoodsReceiptDto, GoodsReceipt>();
            CreateMap<UpdateGoodsReceiptDto, GoodsReceipt>();
        }
    }
}
