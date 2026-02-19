using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface INetOperationService
    {
        Task<ApiResponse<NetOperationDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<NetOperationDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<NetOperationDto>> CreateAsync(CreateNetOperationDto dto);
        Task<ApiResponse<NetOperationDto>> UpdateAsync(long id, UpdateNetOperationDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
        Task<ApiResponse<bool>> Post(long netOperationId, long userId);
    }
}
