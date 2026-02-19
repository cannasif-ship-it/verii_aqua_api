using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface ITransferRepository
    {
        Task<Transfer?> GetForPost(long id);
    }
}
