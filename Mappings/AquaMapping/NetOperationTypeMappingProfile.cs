using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class NetOperationTypeMappingProfile : Profile
    {
        public NetOperationTypeMappingProfile()
        {
            CreateMap<NetOperationType, NetOperationTypeDto>();
            CreateMap<CreateNetOperationTypeDto, NetOperationType>();
            CreateMap<UpdateNetOperationTypeDto, NetOperationType>();
        }
    }
}
