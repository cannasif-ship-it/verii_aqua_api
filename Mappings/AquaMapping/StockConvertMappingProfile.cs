using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class StockConvertMappingProfile : Profile
    {
        public StockConvertMappingProfile()
        {
            CreateMap<StockConvert, StockConvertDto>()
                .ForMember(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectCode : null))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectName : null));
            CreateMap<CreateStockConvertDto, StockConvert>();
            CreateMap<UpdateStockConvertDto, StockConvert>();
        }
    }
}
