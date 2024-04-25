using UtiliSense.Gas.BizRules.Contracts;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            return await _repo.DeleteGasConsumptionAsync(gasConsumptionId);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<GasConsumption?> GetGasConsumptionByDayAsync(DateTime date)
    {
        try
        {
            if (date < new DateTime(2023, 1, 1) || date > DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.", date), nameof(date));
            }

            return await _repo.GetGasConsumptionByDayAsync(date);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateTime date)
    {
        try
        {
            if (date < new DateTime(2023, 1, 1) || date > DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.", date), nameof(date));
            }

            return await _repo.GetGasConsumptionByMonthAsync(date);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateTime date)
    {
        try
        {
            if (date < new DateTime(2023, 1, 1) || date > DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.", date), nameof(date));
            }

            return await _repo.GetGasConsumptionByYearAsync(date);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IEnumerable<GasConsumption>> GetGasConsumptionsAsync()
    {
        try
        {
            return await _repo.GetGasConsumptionsAsync();
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<bool> InsertGasConsumption(GasConsumption gasConsumption)
    {
        try
        {
            var test = DateOnly.FromDateTime(DateTime.UtcNow);
            if (gasConsumption.ConsumptionDate > test)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.",
                    gasConsumption.ConsumptionDate), nameof(gasConsumption.ConsumptionDate));
            }

            if (gasConsumption.ConsumptionDate < DateOnly.FromDateTime(new DateTime(2023, 1, 1)))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.",
                    gasConsumption.ConsumptionDate), nameof(gasConsumption.ConsumptionDate));
            }

            //if (gasConsumption.ConsumptionDate < DateOnly.FromDateTime(new DateTime(2023, 1, 1)) 
            //    || gasConsumption.ConsumptionDate < DateOnly.FromDateTime(DateTime.UtcNow))
            //{
            //    throw new ArgumentOutOfRangeException(string.Format("{0} is out of range.", 
            //        gasConsumption.ConsumptionDate), nameof(gasConsumption.ConsumptionDate));
            //}

            if (gasConsumption.GasConsumptionCcf <= 0)
            {
                throw new ArgumentException(string.Format("{0} is an invalid value.", 
                                       gasConsumption.GasConsumptionCcf), nameof(gasConsumption.GasConsumptionCcf));
            }

            return await _repo.InsertGasConsumptionAsync(gasConsumption);

        }
        catch (Exception)
        {
            return false;
        }
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
