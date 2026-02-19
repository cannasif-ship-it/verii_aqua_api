using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse<ProjectDto>> GetByIdAsync(long id);
        Task<ApiResponse<PagedResponse<ProjectDto>>> GetAllAsync(PagedRequest request);
        Task<ApiResponse<ProjectDto>> CreateAsync(CreateProjectDto dto);
        Task<ApiResponse<ProjectDto>> UpdateAsync(long id, UpdateProjectDto dto);
        Task<ApiResponse<bool>> SoftDeleteAsync(long id);
    }
}
