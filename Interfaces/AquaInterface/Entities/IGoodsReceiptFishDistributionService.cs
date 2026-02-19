using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IGoodsReceiptFishDistributionService
    {
        Task<ApiResponse<GoodsReceiptFishDistributionDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<GoodsReceiptFishDistributionDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<GoodsReceiptFishDistributionDto>> CreateAsync(CreateGoodsReceiptFishDistributionDto dto);
        Task<ApiResponse<GoodsReceiptFishDistributionDto>> UpdateAsync(long id, UpdateGoodsReceiptFishDistributionDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
