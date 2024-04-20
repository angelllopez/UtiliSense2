using UtiliSense.Solar.Data.Models;

namespace UtiliSense.Solar.Data.Contracts
{
    public interface ISolarPowerDataRepository : IDisposable
    {
        Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataAsync();
        Task<SolarPowerActivity> GetSolarPowerActivityDataByDayAsync(DateTime? date);
        Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataByMonthAsync(DateTime date);
        Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataByYearAsync(DateTime date);
        Task<bool> AddSolarPowerActivityDataAsync(SolarPowerActivity record);
        Task<bool> DeleteSolarPowerActivityDataAsync(int id);
        Task<bool> UpdateSolarPowerActivityDataAsync(SolarPowerActivity productionRecord);
    }
}
