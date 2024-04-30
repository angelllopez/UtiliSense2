using Moq;
using UtiliSense.Gas.Services.Contracts;
using UtiliSense.Gas.Services.RulesBook;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.UnitTests.BizRules.RulesBook;

public class RulesTests
{


    [Theory]
    [InlineData(0)] // Invalid isValid
    [InlineData(1)] // Valid isValid
    public async Task DeleteGasConsumptionAsync_Should_HandleValidAndInvalidInput(int gasConsumptionId)
    {
        // Arrange
        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>())).Returns(true);
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);
        mockRepo.Setup(x => x.DeleteGasConsumptionAsync(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        var result = await sut.DeleteGasConsumptionAsync(gasConsumptionId);

        // Assert
        if (gasConsumptionId == 0)
        {
            Assert.False(result);
        }
        else
        {
            Assert.True(result);
        }
    }

    [Theory]
    [InlineData("2022-12-31", false)] // Invalid value
    [InlineData("2023-01-01", true)] // Valid value
    public async Task GetGasConsumptionByDayAsync_Should_HandleValidAndInvalidInput(string date, bool isValid)
    {
        // Arrange
        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>())).Returns(isValid);

        var mockRepo = new Mock<IGasConsumptionRepository>();
        mockRepo.Setup(x => x.GetGasConsumptionByDayAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new GasConsumption());

        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);

        // Act
        var result = await sut.GetGasConsumptionByDayAsync(DateTime.Parse(date));

        // Assert
        if (isValid)
        {
            Assert.NotNull(result);
        }
        else
        {
           Assert.Null(result); 
        }
    }

    [Theory]
    [InlineData("2022-12-31", false)] // Invalid value
    [InlineData("2023-01-01", true)] // Valid value
    public async Task GetGasConsumptionByMonthAsync_Should_HandleValidAndInvalidInput(string date, bool isValid)
    {
        // Arrange
        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>())).Returns(isValid);
        var mockRepo = new Mock<IGasConsumptionRepository>();
        mockRepo.Setup(x => x.GetGasConsumptionByMonthAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });

        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);

        // Act
        var result = await sut.GetGasConsumptionByMonthAsync(DateTime.Parse(date));

        // Assert
        if (isValid)
        {
            Assert.NotEmpty(result);
        }
        else
        {
            Assert.Empty(result);
        }
    }

    [Theory]
    [InlineData("2022-12-31", false)] // Invalid value
    [InlineData("2023-01-01", true)] // Valid value
    public async Task GetGasConsumptionByYearAsync_Should_HandleValidAndInvalidInput(string date, bool isValid)
    {
        // Arrange
        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>())).Returns(isValid);
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);
        mockRepo.Setup(x => x.GetGasConsumptionByYearAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });

        // Act
        var result = await sut.GetGasConsumptionByYearAsync(DateTime.Parse(date));

        // Assert
        if (isValid)
        {
            Assert.NotEmpty(result);
        }
        else
        {
            Assert.Empty(result);
        }
    }

    [Fact]
    public async Task GetGasConsumptionsAsync_Should_HandleException()
    {
        // Arrange
        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>()))
            .Returns(true);

        var mockRepo = new Mock<IGasConsumptionRepository>();
        mockRepo.Setup(x => x.GetGasConsumptionsAsync())
            .ThrowsAsync(new Exception("Simulated error"));

        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);

        // Act
        var result = await sut.GetGasConsumptionsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("2026-12-31", false)] // Invalid value
    //[InlineData("2021-12-31")] // Invalid isValid
    [InlineData("2023-01-01", true)] // Valid value
    public async Task InsertGasConsumption_Should_HandleValidAndInvalidInput(DateTime consumptionDate, bool isValid)
    {
        // Arrange
        var dummyGasConsumption = new GasConsumption
        {
            ConsumptionDate = DateOnly.FromDateTime(consumptionDate),
            GasConsumptionCcf = 1, // Valid value
        };

        var mockCoreServices = new Mock<ICoreServices>();
        mockCoreServices.Setup(x => x.IsDateValid(It.IsAny<DateTime>())).Returns(isValid);


        var mockRepo = new Mock<IGasConsumptionRepository>();
        mockRepo.Setup(x => x.InsertGasConsumptionAsync(It.IsAny<GasConsumption>()))
            .ReturnsAsync(true);

        var sut = new Rules(mockRepo.Object, mockCoreServices.Object);

        // Act
        var result = await sut.InsertGasConsumption(dummyGasConsumption);

        // Assert
        if (isValid)
        {
            Assert.True(result);
        }
        else
        {
            Assert.False(result);
        }
    }
}
