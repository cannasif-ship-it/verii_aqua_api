using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Shipment?> GetForPost(long id);
    }
}
