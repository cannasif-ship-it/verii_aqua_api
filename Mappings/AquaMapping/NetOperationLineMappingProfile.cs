using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class NetOperationLineMappingProfile : Profile
    {
        public NetOperationLineMappingProfile()
        {
            CreateMap<NetOperationLine, NetOperationLineDto>();
            CreateMap<CreateNetOperationLineDto, NetOperationLine>();
            CreateMap<UpdateNetOperationLineDto, NetOperationLine>();
        }
    }
}
