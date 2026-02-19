using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class NetOperationMappingProfile : Profile
    {
        public NetOperationMappingProfile()
        {
            CreateMap<NetOperation, NetOperationDto>();
            CreateMap<CreateNetOperationDto, NetOperation>();
            CreateMap<UpdateNetOperationDto, NetOperation>();
        }
    }
}
