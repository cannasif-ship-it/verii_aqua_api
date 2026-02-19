using aqua_api.Models;
using aqua_api.DTOs;

namespace aqua_api.Interfaces
{
    public interface IJwtService
    {
        ApiResponse<string> GenerateToken(User user);
    }
}
