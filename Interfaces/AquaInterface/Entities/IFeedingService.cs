using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IFeedingService
    {
        Task<ApiResponse<FeedingDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<FeedingDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<FeedingDto>> CreateAsync(CreateFeedingDto dto);
        Task<ApiResponse<FeedingDto>> UpdateAsync(long id, UpdateFeedingDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
