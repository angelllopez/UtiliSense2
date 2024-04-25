using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtiliSense.Gas.BizRules.RulesBook;
using UtiliSense.Gas.Data.Contracts;
using UtiliSense.Gas.Data.Models;

namespace UtiliSense.Gas.UnitTests.BizRules.RulesBook;

public class RulesTests
{
    [Theory]
    [InlineData(0)] // Invalid value
    [InlineData(1)] // Valid value
    public async Task DeleteGasConsumptionAsync_Should_HandleValidAndInvalidInput(int gasConsumptionId)
    {
        // Arrange
        bool result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.DeleteGasConsumptionAsync(It.IsAny<int>())).ReturnsAsync(true);

        // Act
        result = await sut.DeleteGasConsumptionAsync(gasConsumptionId);

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
    [InlineData("2022-12-31")] // Invalid value
    [InlineData("2023-01-01")] // Valid value
    public async Task GetGasConsumptionByDayAsync_Should_HandleValidAndInvalidInput(string date)
    {
        // Arrange
        GasConsumption? result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.GetGasConsumptionByDayAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new GasConsumption());

        // Act
        result = await sut.GetGasConsumptionByDayAsync(DateTime.Parse(date));

        // Assert
        if (DateTime.Parse(date) < new DateTime(2023, 1, 1) || DateTime.Parse(date) > DateTime.UtcNow)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.NotNull(result);
        }
    }

    [Theory]
    [InlineData("2022-12-31")] // Invalid value
    [InlineData("2023-01-01")] // Valid value
    public async Task GetGasConsumptionByMonthAsync_Should_HandleValidAndInvalidInput(string date)
    {
        // Arrange
        IEnumerable<GasConsumption> result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.GetGasConsumptionByMonthAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });

        // Act
        result = await sut.GetGasConsumptionByMonthAsync(DateTime.Parse(date));

        // Assert
        if (DateTime.Parse(date) < new DateTime(2023, 1, 1) || DateTime.Parse(date) > DateTime.UtcNow)
        {
            Assert.Empty(result);
        }
        else
        {
            Assert.NotEmpty(result);
        }
    }

    [Theory]
    [InlineData("2022-12-31")] // Invalid value
    [InlineData("2023-01-01")] // Valid value
    public async Task GetGasConsumptionByYearAsync_Should_HandleValidAndInvalidInput(string date)
    {
        // Arrange
        IEnumerable<GasConsumption> result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.GetGasConsumptionByYearAsync(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<GasConsumption> { new GasConsumption() });

        // Act
        result = await sut.GetGasConsumptionByYearAsync(DateTime.Parse(date));

        // Assert
        if (DateTime.Parse(date) < new DateTime(2023, 1, 1) || DateTime.Parse(date) > DateTime.UtcNow)
        {
            Assert.Empty(result);
        }
        else
        {
            Assert.NotEmpty(result);
        }
    }

    [Fact]
    public async Task GetGasConsumptionsAsync_Should_HandleException()
    {
        // Arrange
        IEnumerable<GasConsumption> result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.GetGasConsumptionsAsync())
            .ThrowsAsync(new Exception("Simulated error"));

        // Act
        result = await sut.GetGasConsumptionsAsync();

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("2026-12-31")] // Invalid value
    [InlineData("2021-12-31")] // Invalid value
    [InlineData("2023-01-01")] // Valid value
    public async Task InsertGasConsumption_Should_HandleValidAndInvalidInput(DateTime consumptionDate)
    {
        // Arrange
        var dummyGasConsumption = new GasConsumption
        {
            ConsumptionDate = DateOnly.FromDateTime(consumptionDate),
            GasConsumptionCcf = 1, // Valid value
        };
        bool result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.InsertGasConsumptionAsync(It.IsAny<GasConsumption>()))
            .ReturnsAsync(true);

        // Act
        result = await sut.InsertGasConsumption(dummyGasConsumption);

        // Assert
        //if (consumptionDate == new DateTime(2022, 12, 31))
        //{
        //    Assert.False(result);
        //}
        //else
        //{
        //    Assert.True(result);
        //}
    }
}
