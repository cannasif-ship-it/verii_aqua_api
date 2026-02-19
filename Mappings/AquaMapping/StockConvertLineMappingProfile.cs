using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class StockConvertLineMappingProfile : Profile
    {
        public StockConvertLineMappingProfile()
        {
            CreateMap<StockConvertLine, StockConvertLineDto>();
            CreateMap<CreateStockConvertLineDto, StockConvertLine>();
            CreateMap<UpdateStockConvertLineDto, StockConvertLine>();
        }
    }
}
