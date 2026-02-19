using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class TransferLineMappingProfile : Profile
    {
        public TransferLineMappingProfile()
        {
            CreateMap<TransferLine, TransferLineDto>();
            CreateMap<CreateTransferLineDto, TransferLine>();
            CreateMap<UpdateTransferLineDto, TransferLine>();
        }
    }
}
