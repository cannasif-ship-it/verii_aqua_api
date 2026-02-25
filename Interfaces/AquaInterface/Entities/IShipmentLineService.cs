using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IShipmentLineService
    {
        Task<ApiResponse<ShipmentLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<ShipmentLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<ShipmentLineDto>> CreateAsync(CreateShipmentLineDto dto);
        Task<ApiResponse<ShipmentLineDto>> UpdateAsync(long id, UpdateShipmentLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
