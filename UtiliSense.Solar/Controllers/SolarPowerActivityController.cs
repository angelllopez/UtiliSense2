using Microsoft.AspNetCore.Mvc;
using UtiliSense.Solar.Data.Contracts;
using UtiliSense.Solar.Data.Models;

namespace UtiliSense.Solar.Controllers;

/// <summary>
/// This is a restful API controller designed to facilite the management of data
/// related to the production and consumption of of electricity produced by a
/// solar power system.
/// </summary>
/// <remarks>
/// Initializes a new instance of the SolarPowerActivityController class.
/// </remarks>
/// <param name="repo">
/// An ISolarPowerDataRepository type that represents the dependency injected.
/// Solar Power Data repository interface
/// </param>
[Route("api/[controller]")]
[ApiController]
public class SolarPowerActivityController(ISolarSystemDataRepository repo) : ControllerBase
{
    private readonly ISolarSystemDataRepository _repo = repo;

    /// <summary>
    /// Retrieves all the solar power activity data records. 
    /// </summary>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>    
    [HttpGet]
    [Route("GetActivity")]
    public async Task<IActionResult> GetSolarPowerActivityDataAsync()
    {
        var solarPowerData = await _repo.GetSolarPowerActivityDataAsync();

        if (!solarPowerData.Any())
        {
            return NotFound();
        }

        return Ok(solarPowerData);
    }

    /// <summary>
    /// Retrives a single solar power activity data record. 
    /// </summary>
    /// <param name="date">
    /// A DateTime value that specifies the date to filter the solar power activity data records.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpGet]
    [Route("GetActivityByDay")]
    public async Task<IActionResult> GetSolarPowerActivityDataByDayAsync(DateTime date)
    {
        var solarPowerData = await _repo.GetSolarPowerActivityDataByDayAsync(date);

        return solarPowerData.SolarPowerActivityId < 1 ? NotFound() : Ok(solarPowerData);
    }

    /// <summary>
    /// Retrieves a collection of solar power activity data records. 
    /// </summary>
    /// <param name="date">
    /// A DateTime value that specifies the month and year to filter the solar power activity data records.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpGet]
    [Route("GetActivityByMonth")]
    public async Task<IActionResult> GetSolarPowerActivityDataByMonthAsync(DateTime date)
    {
        var solarPowerData = await _repo.GetSolarPowerActivityDataByMonthAsync(date);

        return !solarPowerData.Any() ? NotFound() : Ok(solarPowerData);
    }

    /// <summary>
    /// Retrieves a collection of solar power activity data records.
    /// </summary>
    /// <param name="date">
    /// A DateTime value that specifies the year to filter the solar power activity data records.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpGet]
    [Route("GetActivityByYear")]
    public async Task<IActionResult> GetSolarPowerActivityDataByYearAsync(DateTime date)
    {
        var solarPowerData = await _repo.GetSolarPowerActivityDataByYearAsync(date);

        return !solarPowerData.Any() ? NotFound() : Ok(solarPowerData);
    }

    /// <summary>
    /// Adds a sun power activity data record.
    /// </summary>
    /// <param name="solarPowerActivityRecord">
    /// A SolarPowerActivity object that contains the sun power activity data record to add to the repository.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpPost]
    [Route("AddActivity")]
    public async Task<IActionResult> AddSolarPowerActivityDataAsync(SolarPowerActivity solarPowerActivityRecord)
    {
        var result = await _repo.AddSolarPowerActivityDataAsync(solarPowerActivityRecord);

        return result is false ? BadRequest() : Ok();
    }

    /// <summary>
    /// Deletes a solar power activity data record.
    /// </summary>
    /// <param name="id">
    /// An integer value that specifies the solar power activity data record to delete from the repository.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpDelete]
    [Route("DeleteActivity")]
    public async Task<IActionResult> DeleteSolarPowerActivityDataAsync(int id)
    {
        var result = await _repo.DeleteSolarPowerActivityDataAsync(id);

        return result is false ? BadRequest() : Ok();
    }

    /// <summary>
    /// Updates a sun power activity data record.
    /// </summary>
    /// <param name="solarPowerActivityRecord">
    /// A SolarPowerActivity object that contains the solar power activity data record to update in the repository.
    /// </param>
    /// <returns>
    /// A Task IActionResult object that represents the result of the asynchronous operation.
    /// </returns>
    [HttpPut]
    [Route("UpdateActivity")]
    public async Task<IActionResult> UpdateSolarPowerActivityDataAsync(SolarPowerActivity solarPowerActivityRecord)
    {
        var result = await _repo.UpdateSolarPowerActivityDataAsync(solarPowerActivityRecord);

        return result is false ? BadRequest() : Ok();
    }
}
