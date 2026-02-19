using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class TransferMappingProfile : Profile
    {
        public TransferMappingProfile()
        {
            CreateMap<Transfer, TransferDto>()
                .ForMember(dest => dest.ProjectCode, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectCode : null))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.ProjectName : null));
            CreateMap<CreateTransferDto, Transfer>();
            CreateMap<UpdateTransferDto, Transfer>();
        }
    }
}
