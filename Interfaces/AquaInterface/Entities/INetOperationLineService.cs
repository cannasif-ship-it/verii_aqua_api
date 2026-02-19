using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface INetOperationLineService
    {
        Task<ApiResponse<NetOperationLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<NetOperationLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<NetOperationLineDto>> CreateAsync(CreateNetOperationLineDto dto);
        Task<ApiResponse<NetOperationLineDto>> UpdateAsync(long id, UpdateNetOperationLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
