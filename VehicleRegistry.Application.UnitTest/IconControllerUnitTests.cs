using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VehicleRegistry.Application.Icon;
using VehicleRegistry.Application.Icon.Queries.GetAllIcons;
using VehicleRegistry.WebAPI.Controllers;
using Xunit;

namespace VehicleRegistry.Application.UnitTest
{
    // Region: Test Class
    public class IconControllerUnitTests
    {
        // Region: Test Method
        [Fact]
        public async Task GetAllIcons_ReturnsOkResultWithIcons()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var iconDtoList = new List<IconDto>
            {
                new IconDto { Id = 1, Name = "Icon1", Icon = "Path1" },
                new IconDto { Id = 2, Name = "Icon2", Icon = "Path2" }
            };

            // Mock the behavior of the Mediator to return the list of icons
            mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<GetAllIconsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(iconDtoList);

            var controller = new IconController(mockMediator.Object);

            // Act
            var result = await controller.GetAllIcons();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<IconDto>>(okResult.Value);
            Assert.Equal(iconDtoList.Count, model.Count);
        }
        // End of Test Method
    }
    // End of Test Class
}
// End of file

// File Ownership: Kelum
// MIT License Copyright
