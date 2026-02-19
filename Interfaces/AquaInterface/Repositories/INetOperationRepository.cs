using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface INetOperationRepository
    {
        Task<NetOperation?> GetForPost(long id);
    }
}
