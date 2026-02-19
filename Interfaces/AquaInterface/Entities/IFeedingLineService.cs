using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IFeedingLineService
    {
        Task<ApiResponse<FeedingLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<FeedingLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<FeedingLineDto>> CreateAsync(CreateFeedingLineDto dto);
        Task<ApiResponse<FeedingLineDto>> UpdateAsync(long id, UpdateFeedingLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
