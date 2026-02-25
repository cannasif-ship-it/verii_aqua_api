using aqua_api.Data;
using aqua_api.Interfaces;
using aqua_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AquaDbContext _db;

        public ShipmentRepository(AquaDbContext db)
        {
            _db = db;
        }

        public Task<Shipment?> GetForPost(long id)
        {
            return _db.Shipments
                .Include(x => x.Lines)
                .ThenInclude(x => x.FishBatch)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
