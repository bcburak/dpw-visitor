using DpWorld.Visitor.Api.Controllers;
using DpWorld.Visitor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DpWorld.Visitor.Tests
{
    public class CheckInControllerTests
    {
        private readonly Mock<IVisitorService> _mockVisitorService;
        private readonly CheckInController _controller;

        public CheckInControllerTests()
        {
            _mockVisitorService = new Mock<IVisitorService>();
            _controller = new CheckInController(_mockVisitorService.Object);
        }

        [Fact]
        public void CheckIn_ShouldReturnBadRequest_WhenArgumentExceptionThrown()
        {
            // Arrange
            var request = new CheckInRequest
            {
                Name = "Burak Celik",
                Email = "Burak@example.com",
                Company = "Dp-World",
                TeamId = 1,
                EntranceId = "", // Missing Entrance ID
                RulesAccepted = true
            };

            _mockVisitorService.Setup(s => s.CheckIn(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Throws(new ArgumentException("Entrance ID is required."));

            // Act
            var result = _controller.CheckIn(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Entrance ID is required.", badRequestResult.Value);
        }

        [Fact]
        public void CheckIn_ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var request = new CheckInRequest
            {
                Name = "Burak Celik",
                Email = "Burak@example.com",
                Company = "Dp-World",
                TeamId = 1,
                EntranceId = "MAIN-ENTRANCE",
                RulesAccepted = true
            };

            var expectedVisitor = new DpWorld.Visitor.Domain.Entities.Visitor
            {
                Name = request.Name,
                EntranceId = request.EntranceId
            };

            _mockVisitorService.Setup(s => s.CheckIn(
                request.Name, request.Email, request.Company,
                request.TeamId, request.EntranceId, request.RulesAccepted))
                .Returns(expectedVisitor);

            // Act
            var result = _controller.CheckIn(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var visitor = Assert.IsType<DpWorld.Visitor.Domain.Entities.Visitor>(okResult.Value);
            Assert.Equal("Burak Celik", visitor.Name);
            Assert.Equal("MAIN-ENTRANCE", visitor.EntranceId);
        }
    }
}
