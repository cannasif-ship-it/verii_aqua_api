using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IMortalityLineService
    {
        Task<ApiResponse<MortalityLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<MortalityLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<MortalityLineDto>> CreateAsync(CreateMortalityLineDto dto);
        Task<ApiResponse<MortalityLineDto>> UpdateAsync(long id, UpdateMortalityLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
