using aqua_api.Data;
using aqua_api.Interfaces;
using aqua_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AquaDbContext _db;

        public TransferRepository(AquaDbContext db)
        {
            _db = db;
        }

        public Task<Transfer?> GetForPost(long id)
        {
            return _db.Transfers
                .Include(x => x.Lines)
                .ThenInclude(x => x.FishBatch)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
