using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface IMortalityRepository
    {
        Task<Mortality?> GetForPost(long id);
    }
}
