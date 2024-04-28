using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.BizRules.Contracts;

public interface IRules
{
    Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
    Task<GasConsumption?> GetGasConsumptionByDayAsync(DateOnly date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateOnly date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateOnly date);
    Task<bool> InsertGasConsumption(GasConsumption gasConsumption);
    Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId);
    Task<bool> UpdateGasConsumption(GasConsumption gasConsumption);
    void Save();
}