using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtiliSense.Solar.Controllers;
using UtiliSense.Solar.Data.Contracts;
using UtiliSense.Solar.Data.Models;

namespace UtiliSense.Solar.Tests.Service
{
    public class SolarPowerActivityControllerTests
    {
        [Fact]
        [Trait("Category", "GetSolarPowerActivityData")]
        public async Task GetSolarPowerActivityDataAsync_ReturnsOk_WhenRecordsExist()
        {
            //Arrange
            var stubList = new List<SolarPowerActivity>() { new SolarPowerActivity() };
            var mockRepo = new Mock<ISolarSystemDataRepository>(MockBehavior.Strict);

            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataAsync())
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var actual = await sut.GetSolarPowerActivityDataAsync();

            // Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        [Trait("Category", "GetSolarPowerActivityData")]
        public async Task GetSolarPowerActivityDataAsync_ReturnsNotFound_WhenRecordsDoNotExist()
        {
            //Arrange
            List<SolarPowerActivity> stubList = new();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataAsync())
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByDayAsync_ReturnsOk_WhenRecordsExist()
        {
            //Arrange
            var stubRecord = new SolarPowerActivity { SolarPowerActivityId = 1 };
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataByDayAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubRecord);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByDayAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByDayAsync_ReturnsNotFound_WhenRecordDoesNotExist()
        {
            //Arrange
            var stubRecord = new SolarPowerActivity();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataByDayAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubRecord);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByDayAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByMonthAsynct_ReturnsOk_WhenRecordsExist()
        {
            //Arrange
            var stubList = new List<SolarPowerActivity>() { new SolarPowerActivity() };
            var mockRepo = new Mock<ISolarSystemDataRepository>();
            mockRepo.Setup(x =>
                       x.GetSolarPowerActivityDataByMonthAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByMonthAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByMonthAsync_ReturnsNotFound_WhenRecordsDoNotExist()
        {
            //Arrange
            var stubList = new List<SolarPowerActivity>();
            var mockRepo = new Mock<ISolarSystemDataRepository>();
            mockRepo.Setup(x =>
                       x.GetSolarPowerActivityDataByMonthAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByMonthAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByYearAsync_ReturnsOk_WhenRecordsExist()
        {
            //Arrange
            var stubList = new List<SolarPowerActivity>() { new SolarPowerActivity() };
            var mockRepo = new Mock<ISolarSystemDataRepository>();
            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataByYearAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByYearAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSolarPowerActivityDataByYearAsync_ReturnsNotFound_WhenRecordsDoNotExist()
        {
            //Arrange
            var stubList = new List<SolarPowerActivity>();
            var mockRepo = new Mock<ISolarSystemDataRepository>();
            mockRepo.Setup(x =>
                x.GetSolarPowerActivityDataByYearAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(stubList);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.GetSolarPowerActivityDataByYearAsync(new DateTime());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddSolarPowerActivityDataRecord_ReturnsOk_WhenRecordIsAdded()
        {
            //Arrange
            var dummyRecord = new SolarPowerActivity();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                x.AddSolarPowerActivityDataAsync(It.IsAny<SolarPowerActivity>()))
                .ReturnsAsync(true);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.AddSolarPowerActivityDataAsync(dummyRecord);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddSolarPowerActiviryDataAsync_ReturnsBadRequest_WhenRecordIsNotAdded()
        {
            //Arrange
            var dummyRecord = new SolarPowerActivity();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                       x.AddSolarPowerActivityDataAsync(It.IsAny<SolarPowerActivity>()))
                .ReturnsAsync(false);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.AddSolarPowerActivityDataAsync(dummyRecord);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteSolarPowerActivityDataAsync_ReturnsOk_WhenRecordIsDeleted()
        {
            //Arrange
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                       x.DeleteSolarPowerActivityDataAsync(It.IsAny<int>()))
                .ReturnsAsync(true);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.DeleteSolarPowerActivityDataAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteSolarPowerActivityDataAsync_ReturnsBadRequest_WhenRecordIsNotDeleted()
        {
            //Arrange
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                              x.DeleteSolarPowerActivityDataAsync(It.IsAny<int>()))
                .ReturnsAsync(false);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.DeleteSolarPowerActivityDataAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateSolarPowerActivityDataAsync_ReturnsOk_WhenRecordIsUpdated()
        {
            //Arrange
            var dummyRecord = new SolarPowerActivity();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                x.UpdateSolarPowerActivityDataAsync(It.IsAny<SolarPowerActivity>()))
                .ReturnsAsync(true);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.UpdateSolarPowerActivityDataAsync(dummyRecord);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateSolarPowerActivityDataAsync_ReturnsBadRequest_WhenRecordIsNotUpdated()
        {
            //Arrange
            var dummyRecord = new SolarPowerActivity();
            var mockRepo = new Mock<ISolarSystemDataRepository>();

            mockRepo.Setup(x =>
                       x.UpdateSolarPowerActivityDataAsync(It.IsAny<SolarPowerActivity>()))
                .ReturnsAsync(false);

            var sut = new SolarPowerActivityController(mockRepo.Object);

            // Act
            var result = await sut.UpdateSolarPowerActivityDataAsync(dummyRecord);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
