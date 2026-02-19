using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IWeighingLineService
    {
        Task<ApiResponse<WeighingLineDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<WeighingLineDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<WeighingLineDto>> CreateAsync(CreateWeighingLineDto dto);
        Task<ApiResponse<WeighingLineDto>> UpdateAsync(long id, UpdateWeighingLineDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
