using Moq;
using UtiliSense.Gas.BizRules.RulesBook;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.UnitTests.BizRules.RulesBook;

public class RulesTests
{
    public static IEnumerable<object[]> TestGetPersonItemsData => new List<object[]>
    {
        new object[] { 0, 10, new List<string> { "DEV", "IT" }, "", 3 }

    };

    [Theory]
    [InlineData(0, false)] // Invalid value
    [InlineData(-1, false)] // Invalid value
    [InlineData(1, true)] // Valid value
    public async Task DeleteGasConsumptionAsync_Should_HandleValidAndInvalidInput(int gasConsumptionId, bool isValid)
    {
        // Arrange
        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.DeleteGasConsumptionAsync(It.IsAny<int>())).ReturnsAsync(true);
        mockHelper.Setup(x => x.ValidateConsumptionId(It.IsAny<int>()));

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

        // Act
        var result = await sut.DeleteGasConsumptionAsync(gasConsumptionId);

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

    [Theory]
    [InlineData("2022-12-31", false)] // Invalid value
    [InlineData("2023-01-01", true)] // Valid value
    public async Task GetGasConsumptionByDayAsync_Should_HandleValidAndInvalidInput(string dateString, bool isValid)
    {
        // Arrange
        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.GetGasConsumptionByDayAsync(It.IsAny<DateOnly>()))
            .ReturnsAsync(new GasConsumption());
        mockHelper.Setup(x => x.ValidateConsumptionDate(It.IsAny<DateOnly>()));

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

        // Act
        var result = await sut.GetGasConsumptionByDayAsync(DateOnly.Parse(dateString));

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
    public async Task GetGasConsumptionByMonthAsync_Should_HandleValidAndInvalidInput(string dateString, bool isValid)
    {
        // Arrange
        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.GetGasConsumptionByMonthAsync(It.IsAny<DateOnly>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });
        mockHelper.Setup(x => x.ValidateConsumptionId(It.IsAny<int>()));

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

        // Act
        var result = await sut.GetGasConsumptionByMonthAsync(DateOnly.Parse(dateString));

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
    public async Task GetGasConsumptionByYearAsync_Should_HandleValidAndInvalidInput(string dateString, bool isValid)
    {
        // Arrange
        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.GetGasConsumptionByYearAsync(It.IsAny<DateOnly>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });
        mockHelper.Setup(x => x.ValidateConsumptionId(It.IsAny<int>()));

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

        // Act
        var result = await sut.GetGasConsumptionByYearAsync(DateOnly.Parse(dateString));

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
        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.GetGasConsumptionsAsync())
            .ThrowsAsync(new Exception("Simulated error"));
        mockHelper.Setup(x => x.ValidateConsumptionId(It.IsAny<int>()));

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

        // Act
        var result = await sut.GetGasConsumptionsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    //[MemberData(nameof(InsertGasConsumptionData))]
    [InlineData("2026-12-31", false)] // Invalid value
    [InlineData("2021-12-31", false)] // Invalid isValid
    [InlineData("2023-01-01", true)] // Valid value
    public async Task InsertGasConsumption_Should_HandleValidAndInvalidInput(string dateString, bool isValid)
    {
        // Arrange
        var dummyGasConsumption = new GasConsumption
        {
            ConsumptionDate = DateOnly.Parse(dateString),
            GasConsumptionCcf = 1, // Valid value
        };

        var mockRepo = new Mock<IConsumptionDataRepository>();
        var mockHelper = new Mock<IConsumptionDataValidationHelper>();

        mockRepo.Setup(x => x.InsertGasConsumptionAsync(It.IsAny<GasConsumption>()))
            .ReturnsAsync(true);
        mockHelper.Setup(x => x.ValidateConsumptionDate(It.IsAny<DateOnly>()))
            .Throws<ArgumentOutOfRangeException>();

        var sut = new Rules(mockRepo.Object, mockHelper.Object);

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
