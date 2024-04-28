using Microsoft.EntityFrameworkCore;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.FunctionalTests
{
    public class DataFlowIntegrationTests
    {
        private readonly UtilitiesDbContext _context;
        private readonly IConsumptionDataRepository _repo;

        public DataFlowIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<UtilitiesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new UtilitiesDbContext(options);
        }

        //[Fact]
        //[Trait("Endpoints_Repository", "Integration")]
        //public async Task GetGasConsumptionByDayAsync_Endpoint_Should_ReturnGasConsumptionByDay()
        //{
        //    // Arrange





        //    var mockRepo = new Mock<IConsumptionDataRepository>();
        //    var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        //    mockRepo.Setup(x => x.GetGasConsumptionByDayAsync(It.IsAny<DateOnly>()))
        //        .ReturnsAsync(new GasConsumption());
        //    mockHelper.Setup(x => x.ValidateConsumptionDate(It.IsAny<DateOnly>()));

        //    var sut = new Rules(mockRepo.Object, mockHelper.Object);

        //    // Act
        //    var result = await sut.GetGasConsumptionByDayAsync(DateOnly.Parse("2023-01-01"));

        //    // Assert
        //    Assert.NotNull(result);
        //}
    }
}
