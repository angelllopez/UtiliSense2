using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Services.Contracts;

public interface IRules
{
    Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
    Task<GasConsumption?> GetGasConsumptionByDayAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date);
    Task<bool> InsertGasConsumption(GasConsumption gasConsumption);
    Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId);
    Task<bool> UpdateGasConsumption(GasConsumption gasConsumption);
    void Save();
}
