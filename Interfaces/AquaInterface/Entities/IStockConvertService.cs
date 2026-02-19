using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IStockConvertService
    {
        Task<ApiResponse<StockConvertDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<StockConvertDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<StockConvertDto>> CreateAsync(CreateStockConvertDto dto);
        Task<ApiResponse<StockConvertDto>> UpdateAsync(long id, UpdateStockConvertDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
        Task<ApiResponse<bool>> Post(long stockConvertId, long userId);
    }
}
