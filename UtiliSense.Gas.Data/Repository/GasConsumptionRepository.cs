using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Data.Repository;

public class GasConsumptionRepository : IConsumptionDataRepository
{
    public Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<GasConsumption> GetGasConsumptionByDayAsync(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertGasConsumptionAsync(GasConsumption gasConsumption)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateGasConsumptionAsync(GasConsumption gasConsumption)
    {
        throw new NotImplementedException();
    }
}
