using BusinessLogic.PerfectNumber;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PerfectNumber.API.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PerfectNumber.API.Tests
{
    public class PerfectNumberControllerTests
    {
        [Fact]
        public void CheckPerfectNo_ReturnsOkResult()
        {
            // Arrange
            var mockPnService = new Mock<IPerfectNumberService>();
            mockPnService.Setup(p => p.IsPerfectNumber(It.IsAny<int>())).Returns(false);

            var controller = new PerfectNumberController(mockPnService.Object);

            // Act
            var result = controller.Get(0);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void FindPerfectNos_ReturnsOkResult()
        {
            // Arrange
            var mockPnService = new Mock<IPerfectNumberService>();
            mockPnService.Setup(p => p.IsPerfectNumber(It.IsAny<int>())).Returns(false);

            var controller = new PerfectNumberController(mockPnService.Object);

            // Act
            var result = controller.FindPerfectNumbers(0, 0);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
