using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class TransferMappingProfile : Profile
    {
        public TransferMappingProfile()
        {
            CreateMap<Transfer, TransferDto>();
            CreateMap<CreateTransferDto, Transfer>();
            CreateMap<UpdateTransferDto, Transfer>();
        }
    }
}
