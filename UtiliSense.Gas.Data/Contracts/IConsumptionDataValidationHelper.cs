namespace UtiliSense.Gas.Data.Contracts
{
    public interface IConsumptionDataValidationHelper
    {
        void ValidateConsumptionId(int gasConsumptionId);
        void ValidateConsumptionDate(DateOnly consumptionDate);
        void ValidateGasConsumptionCcf(int gasConsumptionCcf);
        void ValidateAvgTemp(string avgTemp);
        void ValidateHighTemp(string highTemp);
        void ValidateLowTemp(string lowTemp);
        void ValidateBillingMonth(DateOnly billingMonth);

    }
}
