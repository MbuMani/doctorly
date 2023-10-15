using doctorly.Api.Controllers;
using doctorly.Core.Handlers;
using doctorly.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace doctorly.Tests.Api
{
    [TestClass]
    public class EventControllerTests
    {
        [TestMethod]
        public void CreateEvent_ReturnsOk()
        {
            // Arrange
            var handlerMock = new Mock<IEventCoreHandler>();
            var controller = new EventController();
            var externalEventContract = new ExternalEventContract
            {
                Title = "Testing Create Method",
                Attendees = new List<ExternalAttendeeContract>
            {
                new ExternalAttendeeContract
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            // Act
            var result = controller.CreateEvent(handlerMock.Object, externalEventContract) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void UpdateEvent_ReturnsOk()
        {
            // Arrange
            var handlerMock = new Mock<IEventCoreHandler>();
            var controller = new EventController();
            var externalEventContract = new ExternalEventContract
            {
                Title = "Testing Update Method",
                Attendees = new List<ExternalAttendeeContract>
            {
                new ExternalAttendeeContract
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            // Act
            var result = controller.UpdateEvent(handlerMock.Object, externalEventContract) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void DeleteEvent_InvokesDeleteEventOnHandler()
        {
            // Arrange
            var handlerMock = new Mock<IEventCoreHandler>();
            var controller = new EventController();
            var externalEventContract = new ExternalEventContract
            {
                Title = "Testing Delete Method",
                Attendees = new List<ExternalAttendeeContract>
            {
                new ExternalAttendeeContract
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            // Act
            controller.DeleteEvent(handlerMock.Object, externalEventContract);

            // Assert
            handlerMock.Verify(x => x.DeleteEvent(externalEventContract), Times.Once);
        }

        [TestMethod]
        public void DeleteEvent_ReturnsOk()
        {
            // Arrange
            var handlerMock = new Mock<IEventCoreHandler>();
            var controller = new EventController();
            var externalEventContract = new ExternalEventContract
            {
                Title = "Testing Delete Method",
                Attendees = new List<ExternalAttendeeContract>
            {
                new ExternalAttendeeContract
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            // Act
            var result = controller.DeleteEvent(handlerMock.Object, externalEventContract);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void GetEvents_ReturnsOk()
        {
            // Arrange
            var handlerMock = new Mock<IEventCoreHandler>();
            var controller = new EventController();

            // Act
            var result = controller.GetEvents(handlerMock.Object) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
