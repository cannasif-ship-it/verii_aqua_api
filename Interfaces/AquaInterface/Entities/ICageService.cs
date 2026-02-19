using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface ICageService
    {
        Task<ApiResponse<CageDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<CageDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<CageDto>> CreateAsync(CreateCageDto dto);
        Task<ApiResponse<CageDto>> UpdateAsync(long id, UpdateCageDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
