using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtiliSense.Gas.BizRules.RulesBook;
using UtiliSense.Gas.Data.Contracts;

namespace UtiliSense.Gas.UnitTests.BizRules.RulesBook;

public class RulesTests
{
    [Theory]
    [InlineData(0)] // Invalid value
    [InlineData(1)] // Valid value
    public async Task DeleteGasConsumption_Should_HandleValidAndInvalidInput(int gasConsumptionId)
    {
        // Arrange
        bool result;
        var mockRepo = new Mock<IGasConsumptionRepository>();
        var sut = new Rules(mockRepo.Object);
        mockRepo.Setup(x => x.DeleteGasConsumption(It.IsAny<int>())).ReturnsAsync(true);

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
}
