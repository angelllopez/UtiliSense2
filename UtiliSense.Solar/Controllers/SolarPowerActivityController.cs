using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UtiliSense.Solar.Data.Contracts;
using UtiliSense.Solar.Data.Models;

namespace UtiliSense.Solar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolarPowerActivityController : ControllerBase
    {
        private readonly ISolarPowerDataRepository _repo;

        /// <summary>
        /// Initializes a new instance of the SolarPowerActivityController class.
        /// </summary>
        /// <param name="dataService">
        /// An ISolarPowerDataRepository type that represents the dependency injected.
        /// Solar Power Data repository interface
        /// </param>
        public SolarPowerActivityController(ISolarPowerDataRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Asynchronously retrieves all the solar power activity data records from the repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 
        /// or 404. If the solar power activity data is available, it returns Ok(solarPowerData). If not,
        /// it returns NotFound().
        /// </summary>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>    
        [HttpGet]
        [Route("GetSolarPowerActivityData")]
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
        /// Asynchronously retrives a single solar power activity data record from the repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record property date matches the date parameter, it returns Ok(solarPowerData). If not,
        /// it returns NotFound().
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the date to filter the solar power activity data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpGet]
        [Route("GetSolarPowerActivityDataByDay")]
        public async Task<IActionResult> GetSolarPowerActivityDataByDayAsync(DateTime date)
        {
            var solarPowerData = await _repo.GetSolarPowerActivityDataByDayAsync(date);

            return solarPowerData.SolarPowerActivityId < 1 ? NotFound() : Ok(solarPowerData);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of solar power activity data records from a repository and 
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record properties Date.Month and Date.Year matches the date.month and date.year parameters, 
        /// it returns Ok(solarPowerData). If not, it returns NotFound().
        /// or returns a 404 status code if no record is found.
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the month and year to filter the solar power activity data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpGet]
        [Route("GetSolarPowerActivityDataByMonth")]
        public async Task<IActionResult> GetSolarPowerActivityDataByMonthAsync(DateTime date)
        {
            var solarPowerData = await _repo.GetSolarPowerActivityDataByMonthAsync(date);

            return !solarPowerData.Any() ? NotFound() : Ok(solarPowerData);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of solar power activity data records from a repository and
        /// returns an IActionResult type that represents two possible HTTP status codes: 200 or 404.
        /// If record property Date.Year matches the date.year parameter, it returns Ok(solarPowerData).
        /// If not, it returns NotFound().
        /// </summary>
        /// <param name="date">
        /// A DateTime value that specifies the year to filter the solar power activity data records.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpGet]
        [Route("GetSolarPowerActivityDataByYear")]
        public async Task<IActionResult> GetSolarPowerActivityDataByYearAsync(DateTime date)
        {
            var solarPowerData = await _repo.GetSolarPowerActivityDataByYearAsync(date);

            return !solarPowerData.Any() ? NotFound() : Ok(solarPowerData);
        }

        /// <summary>
        /// Asynchronously adds a sun power activity data record to the repository and returns an IActionResult
        /// type that represents two possible HTTP status codes: 200 or 400. If the add operation is
        /// successful, it returns Ok(). If not, it returns BadRequest().
        /// </summary>
        /// <param name="solarPowerActivityRecord">
        /// A SolarPowerActivity object that contains the sun power activity data record to add to the repository.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpPost]
        [Route("AddSunPowerActivityData")]
        public async Task<IActionResult> AddSolarPowerActivityDataAsync(SolarPowerActivity solarPowerActivityRecord)
        {
            var result = await _repo.AddSolarPowerActivityDataAsync(solarPowerActivityRecord);

            return result is false ? BadRequest() : Ok();
        }

        /// <summary>
        /// Asynchronously deletes a solar power activity data record from the repository and returns an IActionResult
        /// type that represents two possible HTTP status codes: 200 or 400. If the delete operation is
        /// successful, it returns Ok(). If not, it returns BadRequest().
        /// </summary>
        /// <param name="id">
        /// An integer value that specifies the solar power activity data record to delete from the repository.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpDelete]
        [Route("DeleteSolarPowerActivityData")]
        public async Task<IActionResult> DeleteSolarPowerActivityDataAsync(int id)
        {
            var result = await _repo.DeleteSolarPowerActivityDataAsync(id);

            return result is false ? BadRequest() : Ok();
        }

        /// <summary>
        /// Asynchronously updates a sun power activity data record in the repository and returns an IActionResult
        /// type that represents two possible HTTP status codes: 200 or 400. If the update operation is
        /// successful, it returns Ok(). If not, it returns BadRequest().
        /// </summary>
        /// <param name="solarPowerActivityRecord">
        /// A SolarPowerActivity object that contains the solar power activity data record to update in the repository.
        /// </param>
        /// <returns>
        /// A Task IActionResult object that represents the result of the asynchronous operation.
        /// </returns>
        [HttpPut]
        [Route("UpdateSolarPowerActivityData")]
        public async Task<IActionResult> UpdateSolarPowerActivityDataAsync(SolarPowerActivity solarPowerActivityRecord)
        {
            var result = await _repo.UpdateSolarPowerActivityDataAsync(solarPowerActivityRecord);

            return result is false ? BadRequest() : Ok();
        }
    }
}
