using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class ShipmentLineMappingProfile : Profile
    {
        public ShipmentLineMappingProfile()
        {
            CreateMap<ShipmentLine, ShipmentLineDto>();
            CreateMap<CreateShipmentLineDto, ShipmentLine>();
            CreateMap<UpdateShipmentLineDto, ShipmentLine>();
        }
    }
}
