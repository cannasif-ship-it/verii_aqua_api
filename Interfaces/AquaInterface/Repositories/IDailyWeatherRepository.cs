using aqua_api.Models;

namespace aqua_api.Interfaces
{
    public interface IDailyWeatherRepository
    {
        Task<bool> ExistsByProjectAndDate(long projectId, DateTime date);
        Task Add(DailyWeather entity);
    }
}
