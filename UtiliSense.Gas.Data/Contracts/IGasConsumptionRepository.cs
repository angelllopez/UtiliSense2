using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Data.Contracts
{
    public interface IGasConsumptionRepository : IDisposable
    {
        Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync();
        Task<IEnumerable<GasConsumption>> GetGasConsumptionByDayAsync(DateTime date);
        Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date);
        Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date);
        Task<bool> InsertGasConsumption(GasConsumption gasConsumption);
        Task<bool> DeleteGasConsumption(int gasConsumptionId);
        Task<bool> UpdateGasConsumption(GasConsumption gasConsumption);
        void Save();
    }
}
