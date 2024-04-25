using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Data.Contracts;

public interface IGasConsumptionRepository : IDisposable
{
    Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
    Task<GasConsumption> GetGasConsumptionByDayAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date);
    Task<bool> InsertGasConsumptionAsync(GasConsumption gasConsumption);
    Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId);
    Task<bool> UpdateGasConsumptionAsync(GasConsumption gasConsumption);
    void Save();
}
