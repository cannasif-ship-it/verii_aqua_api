using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IGoodsReceiptLineService
    {
        Task<ApiResponse<GoodsReceiptLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<GoodsReceiptLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<GoodsReceiptLineDto>> CreateAsync(CreateGoodsReceiptLineDto dto);
        Task<ApiResponse<GoodsReceiptLineDto>> UpdateAsync(long id, UpdateGoodsReceiptLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
