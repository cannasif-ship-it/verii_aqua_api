using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface IWeighingRepository
    {
        Task<Weighing?> GetForPost(long id);
    }
}
