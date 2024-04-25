using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.Data.Repository
{
    public class GasConsumptionRepository : IGasConsumptionRepository
    {
        public Task<bool> DeleteGasConsumption(int gasConsumptionId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
}
