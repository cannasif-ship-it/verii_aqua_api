using aqua_api.Data;
using aqua_api.Interfaces;
using aqua_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Repositories
{
    public class NetOperationRepository : INetOperationRepository
    {
        private readonly AquaDbContext _db;

        public NetOperationRepository(AquaDbContext db)
        {
            _db = db;
        }

        public Task<NetOperation?> GetForPost(long id)
        {
            return _db.NetOperations
                .Include(x => x.Lines)
                .ThenInclude(x => x.FishBatch)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
