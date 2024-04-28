using UtiliSense.Gas.Data.Contracts;

namespace UtiliSense.Gas.Data.Helpers;

public class GasConsumptionValidationHelper : IConsumptionDataValidationHelper
{
    public void ValidateAvgTemp(string avgTemp)
    {
        throw new NotImplementedException();
    }

    public void ValidateBillingMonth(DateOnly billingMonth)
    {
        throw new NotImplementedException();
    }

    public void ValidateConsumptionDate(DateOnly consumptionDate)
    {
        // Check if consumptionDate is earlier than solarSystemGoLiveDate
        if (consumptionDate < GlobalData.solarSystemGoLiveDate)
        {
            throw new ArgumentOutOfRangeException(nameof(consumptionDate),
                $"Consumption date cannot be earlier than the solar system go-live date ({GlobalData.solarSystemGoLiveDate}).");
        }

        // Check if consumptionDate is later than current date
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        if (consumptionDate > currentDate)
        {
            throw new ArgumentOutOfRangeException(nameof(consumptionDate),
                "Consumption date cannot be in the future.");
        }
    }

    public void ValidateGasConsumptionCcf(int gasConsumptionCcf)
    {
        throw new NotImplementedException();
    }

    public void ValidateConsumptionId(int gasConsumptionId)
    {
        throw new NotImplementedException();
    }

    public void ValidateHighTemp(string highTemp)
    {
        throw new NotImplementedException();
    }

    public void ValidateLowTemp(string lowTemp)
    {
        throw new NotImplementedException();
    }
}
