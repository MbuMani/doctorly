using AutoMapper;
using doctorly.Core.Handlers;
using doctorly.Core.Models;
using doctorly.Persistence.Managers;
using doctorly.Persistence.Models;
using Microsoft.Extensions.Logging;
using Moq;
using doctorly.Core.Handlers.Impl;

namespace doctorly.Tests.Core
{
    [TestClass]
    public class EventHandlerTests
    {
        private Mock<IEventManager> eventManagerMock;
        private Mock<IMapper> mapperMock;
        private Mock<ILogger<EventCoreHandler>> loggerMock;
        private EventCoreHandler eventHandler;

        [TestInitialize]
        public void Initialize()
        {
            eventManagerMock = new Mock<IEventManager>();
            mapperMock = new Mock<IMapper>();
            loggerMock = new Mock<ILogger<EventCoreHandler>>();

            eventHandler = new EventCoreHandler(eventManagerMock.Object, mapperMock.Object, loggerMock.Object);
        }

        [TestMethod]
        public void CreateEvent_Success()
        {
            // Arrange
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

            var newEvent = new Event
            {
                Title = "Testing Create Method",
                Attendees = new List<Attendee>
            {
                new Attendee
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            var savedEvent = new Event
            {
                Title = "Testing Create Method",
                Attendees = new List<Attendee>
            {
                new Attendee
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            mapperMock.Setup(m => m.Map<Event>(externalEventContract)).Returns(newEvent);
            eventManagerMock.Setup(m => m.CreateEvent(newEvent)).Returns(savedEvent);
            mapperMock.Setup(m => m.Map<ExternalEventContract>(savedEvent)).Returns(externalEventContract);

            // Act
            var result = eventHandler.CreateEvent(externalEventContract);

            // Assert
            Assert.AreEqual(externalEventContract, result);
            eventManagerMock.Verify(m => m.CreateEvent(newEvent), Times.Once);
        }

        [TestMethod]
        public void UpdateEvent_Success()
        {
            // Arrange
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

            var newEvent = new Event
            {
                Title = "Testing Create Method",
                Attendees = new List<Attendee>
            {
                new Attendee
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            var savedEvent = new Event
            {
                Title = "Testing Create Method",
                Attendees = new List<Attendee>
            {
                new Attendee
                {
                    Name = "Test",
                    Email = "Test.User@company.com",
                    isAttending = true
                }
            },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            mapperMock.Setup(m => m.Map<Event>(externalEventContract)).Returns(newEvent);
            eventManagerMock.Setup(m => m.UpdateEvent(newEvent)).Returns(savedEvent);
            mapperMock.Setup(m => m.Map<ExternalEventContract>(savedEvent)).Returns(externalEventContract);

            // Act
            var result = eventHandler.UpdateEvent(externalEventContract);

            // Assert
            Assert.AreEqual(externalEventContract, result);
            eventManagerMock.Verify(m => m.UpdateEvent(newEvent), Times.Once);
        }

        [TestMethod]
        public void DeleteEvent_Success()
        {
            // Arrange
            var externalEventContract = new ExternalEventContract
            {
                Title = "Testing DeleteEvent Method"
            };
            var existingEvent = new Event();
            mapperMock.Setup(m => m.Map<Event>(externalEventContract)).Returns(existingEvent);

            // Act
            eventHandler.DeleteEvent(externalEventContract);

            // Assert
            eventManagerMock.Verify(m => m.DeleteEvent(existingEvent), Times.Once);
        }

        [TestMethod]
        public void GetEvents_Success()
        {
            // Arrange
            var externalEvents = new List<ExternalEventContract>
            {
                new ExternalEventContract
                {
                    Title = "Event 1"
                },
                new ExternalEventContract
                {
                    Title = "Event 2"
                }
            };

            var internalEvents = new List<Event>
            {
                new Event
                {
                    Title = "Event 1"
                },
                new Event
                {
                    Title = "Event 2"
                }
            };

            mapperMock.Setup(m => m.Map<List<ExternalEventContract>>(internalEvents)).Returns(externalEvents);
            eventManagerMock.Setup(m => m.GetEvents()).Returns(internalEvents);

            // Act
            var result = eventHandler.GetEvents();

            // Assert
            CollectionAssert.AreEqual(externalEvents, result);
        }
    }
}
