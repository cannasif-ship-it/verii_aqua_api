using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class GoodsReceiptLineMappingProfile : Profile
    {
        public GoodsReceiptLineMappingProfile()
        {
            CreateMap<GoodsReceiptLine, GoodsReceiptLineDto>();
            CreateMap<CreateGoodsReceiptLineDto, GoodsReceiptLine>();
            CreateMap<UpdateGoodsReceiptLineDto, GoodsReceiptLine>();
        }
    }
}
