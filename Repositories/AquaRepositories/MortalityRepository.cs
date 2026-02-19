using aqua_api.Data;
using aqua_api.Interfaces;
using aqua_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aqua_api.Repositories
{
    public class MortalityRepository : IMortalityRepository
    {
        private readonly AquaDbContext _db;

        public MortalityRepository(AquaDbContext db)
        {
            _db = db;
        }

        public Task<Mortality?> GetForPost(long id)
        {
            return _db.Mortalities
                .Include(x => x.Lines)
                .ThenInclude(x => x.FishBatch)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
