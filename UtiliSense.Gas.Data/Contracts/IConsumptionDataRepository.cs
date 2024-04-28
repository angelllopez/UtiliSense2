using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Data.Contracts;

public interface IConsumptionDataRepository : IDisposable
{
    Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
    Task<GasConsumption> GetGasConsumptionByDayAsync(DateOnly date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateOnly date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateOnly date);
    Task<bool> InsertGasConsumptionAsync(GasConsumption gasConsumption);
    Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId);
    Task<bool> UpdateGasConsumptionAsync(GasConsumption gasConsumption);
    void Save();
}
