using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface IStockConvertRepository
    {
        Task<StockConvert?> GetForPost(long id);
    }
}
