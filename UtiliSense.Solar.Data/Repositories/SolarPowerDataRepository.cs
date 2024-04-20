using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UtiliSense.Solar.Data.Contracts;
using UtiliSense.Solar.Data.Models;

namespace UtiliSense.Solar.Data.Repositories;

public class SolarPowerDataRepository : ISolarPowerDataRepository
{
    private readonly UtilitiesDbContext _context;
    private readonly ILogger<SolarPowerDataRepository>? _logger;

    public SolarPowerDataRepository(UtilitiesDbContext context, ILogger<SolarPowerDataRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> AddSolarPowerActivityDataAsync(SolarPowerActivity record)
    {
        var methodName = nameof(AddSolarPowerActivityDataAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        try
        {
            if (_context.SolarPowerActivities.Any(x => x.ActivityDate == record.ActivityDate))
            {
                throw new Exception("Record already exists.");
            }
            else
            {
                _context.SolarPowerActivities.Add(record);
                await _context.SaveChangesAsync();

                _logger?.LogInformation(
                    "Completed {@MethodName} at {@DateTimeUtc} with result count of 1 record.",
                    methodName, DateTime.UtcNow);

                return true;
            }
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                methodName,
                DateTime.UtcNow);

            return false;
        }
    }

    public async Task<bool> DeleteSolarPowerActivityDataAsync(int id)
    {
        var methodName = nameof(DeleteSolarPowerActivityDataAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        try
        {
            var record = await _context.SolarPowerActivities.FindAsync(id);
            if (record is not null)
            {
                _context.SolarPowerActivities.Remove(record);
                await _context.SaveChangesAsync();

                _logger?.LogInformation(
                    "Completed {@MethodName} at {@DateTimeUtc} with result count of 1 record.",
                    methodName, DateTime.UtcNow);

                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Record with id {id} not found.");
            }

        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                methodName,
                DateTime.UtcNow);

            return false;
        }
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);

        _logger?.LogInformation(
        "Completed Dispose at {@DateTimeUtc}.", DateTime.UtcNow);
    }

    public async Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataAsync()
    {
        var methodName = nameof(GetSolarPowerActivityDataAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        List<SolarPowerActivity> results = [];
        try
        {
            results = await _context.SolarPowerActivities
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(true);

            _logger?.LogInformation(
                "Completed {@MethodName} at {@DateTimeUtc} with result count of {@ResultCount} records.",
                methodName,
                DateTime.UtcNow,
                results.Count);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                    methodName,
                    DateTime.UtcNow);
        }

        return results;
    }

    public async Task<SolarPowerActivity> GetSolarPowerActivityDataByDayAsync(DateTime? date)
    {
        var methodName = nameof(GetSolarPowerActivityDataByDayAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.",
            methodName,
            DateTime.UtcNow);

        SolarPowerActivity? result = new();
        try
        {
            result = await _context.SolarPowerActivities
                .Where(x => x.ActivityDate.Equals(date))
                .AsNoTracking()
                .SingleAsync()
                .ConfigureAwait(true);

            _logger?.LogInformation(
                "Completed {@MethodName} at {@DateTimeUtc} with result count of 1 record.",
                methodName, DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                    methodName, DateTime.UtcNow);
        }

        return result;
    }

    public async Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataByMonthAsync(DateTime date)
    {
        var methodName = nameof(GetSolarPowerActivityDataByMonthAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        IEnumerable<SolarPowerActivity> results = Enumerable.Empty<SolarPowerActivity>();
        try
        {
            // return a collection that matches year and month.
            results = await _context.SolarPowerActivities
                .Where(x => x.ActivityDate.Month == date.Month && x.ActivityDate.Year == date.Year)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            if (!results.Any())
            {
                throw new Exception($"No data found for {date.Month}/{date.Year}.");
            }

            _logger?.LogInformation(
                "Completed {@MethodName} at {@DateTimeUtc} with result count of {@ResultCount} records.",
                methodName,
                DateTime.UtcNow,
                results.Count());
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                methodName,
                DateTime.UtcNow);
        }

        return results;
    }

    public async Task<IEnumerable<SolarPowerActivity>> GetSolarPowerActivityDataByYearAsync(DateTime date)
    {
        var methodName = nameof(GetSolarPowerActivityDataByYearAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        IEnumerable<SolarPowerActivity> results = Enumerable.Empty<SolarPowerActivity>();
        try
        {
            results = await _context.SolarPowerActivities
                .Where(x => x.ActivityDate.Year == date.Year)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);

            if (!results.Any())
            {
                throw new Exception($"No data found for the year {date.Year}.");
            }

            _logger?.LogInformation(
                "Completed {@MethodName} at {@DateTimeUtc} with result count of {@ResultCount} records.",
                methodName,
                DateTime.UtcNow,
                results.Count());
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                methodName,
                DateTime.UtcNow);
        }

        return results;
    }

    public async Task<bool> UpdateSolarPowerActivityDataAsync(SolarPowerActivity solarPowerActivityRecord)
    {
        var methodName = nameof(UpdateSolarPowerActivityDataAsync);
        _logger?.LogInformation(
            "Starting {@MethodName} at {@DateTimeUtc}.", methodName, DateTime.UtcNow);

        try
        {

            SolarPowerActivity? record = await _context.SolarPowerActivities.FindAsync(solarPowerActivityRecord.SolarPowerActivityId);

            if (record is not null)
            {
                _context.SolarPowerActivities.Update(solarPowerActivityRecord);
                await _context.SaveChangesAsync();

                _logger?.LogInformation(
                    "Completed {@MethodName} at {@DateTimeUtc} with result count of 1 record.",
                    methodName, DateTime.UtcNow);

                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Record with id {solarPowerActivityRecord.SolarPowerActivityId} not found.");
            }

        }
        catch (Exception ex)
        {
            _logger?.LogError(ex,
                "Failed {@MethodName} at {@DateTimeUtc}.",
                methodName,
                DateTime.UtcNow);

            return false;
        }
    }
}
