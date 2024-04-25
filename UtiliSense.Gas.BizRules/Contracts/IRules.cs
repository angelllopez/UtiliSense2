using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.BizRules.Contracts;

public interface IRules
{
    Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByDayAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date);
    Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date);
    Task<bool> InsertGasConsumption(GasConsumption gasConsumption);
    Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId);
    Task<bool> UpdateGasConsumption(GasConsumption gasConsumption);
    void Save();
}
