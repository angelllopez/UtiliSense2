using UtiliSense.Gas.BizRules.Contracts;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.BizRules.RulesBook;

/// <summary>
/// Business rules for GasConsumption.
/// </summary>
public class Rules : IRules
{
    private readonly IGasConsumptionRepository _repo;

    public Rules(IGasConsumptionRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// Validates the consumption data record id againts the business rules. If the id is valid,
    /// it passes it to the repository's delete operation to be asynchronously deleted from the
    /// database. The result of the operation is then returned. If the id is invalid, it throws
    /// an exception.
    /// </summary>
    /// <param name="gasConsumptionId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId)
    {
        try
        {
            if (gasConsumptionId <= 0)
            {
                throw new ArgumentException(string.Format("{0} is an invalid value.", 
                    gasConsumptionId), nameof(gasConsumptionId));
            }

            return await _repo.DeleteGasConsumption(gasConsumptionId);
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionByDayAsync(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertGasConsumption(GasConsumption gasConsumption)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateGasConsumption(GasConsumption gasConsumption)
    {
        throw new NotImplementedException();
    }
}
