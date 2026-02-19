using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class StockConvertMappingProfile : Profile
    {
        public StockConvertMappingProfile()
        {
            CreateMap<StockConvert, StockConvertDto>();
            CreateMap<CreateStockConvertDto, StockConvert>();
            CreateMap<UpdateStockConvertDto, StockConvert>();
        }
    }
}
