using UtiliSense.Gas.BizRules.Contracts;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.BizRules.RulesBook;

/// <summary>
/// Business rules for GasConsumption.
/// </summary>
public class Rules(IConsumptionDataRepository repo, IConsumptionDataValidationHelper helper) : IRules
{
    private readonly IConsumptionDataRepository _repo = repo;
    private readonly IConsumptionDataValidationHelper _helper = helper;

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

    public async Task<GasConsumption?> GetGasConsumptionByDayAsync(DateOnly consumptionDate)
    {
        try
        {
            _helper.ValidateConsumptionDate(consumptionDate);
            return await _repo.GetGasConsumptionByDayAsync(consumptionDate);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<IEnumerable<GasConsumption>> GetGasConsumptionByYearAsync(DateOnly consumptionDate)
    {
        try
        {
            _helper.ValidateConsumptionDate(consumptionDate);
            return await _repo.GetGasConsumptionByYearAsync(consumptionDate);
        }
        catch (Exception)
        {
            return [];
        }
    }

    public async Task<IEnumerable<GasConsumption>> GetGasConsumptionByMonthAsync(DateOnly consumptionDate)
    {
        try
        {
            _helper.ValidateConsumptionDate(consumptionDate);
            return await _repo.GetGasConsumptionByMonthAsync(consumptionDate);
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
            _helper.ValidateConsumptionDate(gasConsumption.ConsumptionDate);
            _helper.ValidateGasConsumptionCcf(gasConsumption.GasConsumptionCcf);
            _helper.ValidateAvgTemp(gasConsumption.AvgTemp);
            _helper.ValidateHighTemp(gasConsumption.HighTemp);
            _helper.ValidateLowTemp(gasConsumption.LowTemp);
            _helper.ValidateBillingMonth(gasConsumption.BillingMonth);

            return await _repo.InsertGasConsumptionAsync(gasConsumption);
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteGasConsumptionAsync(int gasConsumptionId)
      {
          try
          {
              _helper.ValidateConsumptionId(gasConsumptionId);
              return await _repo.DeleteGasConsumptionAsync(gasConsumptionId);
          }
          catch (Exception)
          {
              return false;
          }
      }
    public async Task<bool> UpdateGasConsumption(GasConsumption gasConsumption)
    {
        try
        {
            _helper.ValidateConsumptionDate(gasConsumption.ConsumptionDate);
            _helper.ValidateGasConsumptionCcf(gasConsumption.GasConsumptionCcf);
            _helper.ValidateAvgTemp(gasConsumption.AvgTemp);
            _helper.ValidateHighTemp(gasConsumption.HighTemp);
            _helper.ValidateLowTemp(gasConsumption.LowTemp);
            _helper.ValidateBillingMonth(gasConsumption.BillingMonth);

            return await _repo.UpdateGasConsumptionAsync(gasConsumption);
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
}
