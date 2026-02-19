using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IMortalityService
    {
        Task<ApiResponse<MortalityDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<MortalityDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<MortalityDto>> CreateAsync(CreateMortalityDto dto);
        Task<ApiResponse<MortalityDto>> UpdateAsync(long id, UpdateMortalityDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
        Task<ApiResponse<bool>> Post(long mortalityId, long userId);
    }
}
