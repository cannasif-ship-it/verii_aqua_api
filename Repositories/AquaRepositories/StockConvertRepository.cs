using aqua_api.Data;
using aqua_api.Interfaces;
using aqua_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Repositories
{
    public class StockConvertRepository : IStockConvertRepository
    {
        private readonly AquaDbContext _db;

        public StockConvertRepository(AquaDbContext db)
        {
            _db = db;
        }

        public Task<StockConvert?> GetForPost(long id)
        {
            return _db.StockConverts
                .Include(x => x.Lines)
                .ThenInclude(x => x.FromFishBatch)
                .Include(x => x.Lines)
                .ThenInclude(x => x.ToFishBatch)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
