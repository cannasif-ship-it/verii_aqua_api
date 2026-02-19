using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IPermissionAccessService
    {
        Task<ApiResponse<MyPermissionsDto>> GetMyPermissionsAsync();
    }
}
