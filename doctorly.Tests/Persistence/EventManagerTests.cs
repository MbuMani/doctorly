using doctorly.Persistence.Models;
using doctorly.Persistence;
using Microsoft.EntityFrameworkCore;
using doctorly.Persistence.Managers.Impl;

namespace doctorly.Tests.Persistence
{
    [TestClass]
    public class EventManagerTests
    {
        private DbContextOptions<DoctorlyContext> dbContextOptions;
        private DoctorlyContext dbContext;
        private EventManager eventManager;

        [TestInitialize]
        public void Initialize()
        {
            // Create a new in-memory database for testing.
            dbContextOptions = new DbContextOptionsBuilder<DoctorlyContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new DoctorlyContext(dbContextOptions);
            eventManager = new EventManager(dbContext);

            SeedTestData();
        }

        private void SeedTestData()
        {
            var events = new Event[]
            {
            new Event { Title = "Event 1" },
            new Event { Title = "Event 2" },
            new Event { Title = "Event 3" }
            };

            dbContext.Events.AddRange(events);
            dbContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbContext.Dispose();
        }

        [TestMethod]
        public void CreateEvent_Success()
        {
            // Arrange
            var newEvent = new Event { Title = "New Event" };

            // Act
            var result = eventManager.CreateEvent(newEvent);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newEvent, result);

            var storedEvent = dbContext.Events.Find(result.Id);
            Assert.IsNotNull(storedEvent);
            Assert.AreEqual(newEvent, storedEvent);
        }

        [TestMethod]
        public void DeleteEvent_Success()
        {
            // Arrange
            var existingEvent = dbContext.Events.First();

            // Act
            eventManager.DeleteEvent(existingEvent);

            // Assert
            var storedEvent = dbContext.Events.Find(existingEvent.Id);
            Assert.IsNull(storedEvent);
        }

        [TestMethod]
        public void GetEvents_Success()
        {
            // Act
            var events = eventManager.GetEvents();

            // Assert
            Assert.IsNotNull(events);
            Assert.AreEqual(9, events.Count);
        }

        [TestMethod]
        public void UpdateEvent_Success()
        {
            // Arrange
            var existingEvent = dbContext.Events.First();
            existingEvent.Title = "Updated Event";

            // Act
            var result = eventManager.UpdateEvent(existingEvent);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingEvent, result);

            var storedEvent = dbContext.Events.Find(existingEvent.Id);
            Assert.IsNotNull(storedEvent);
            Assert.AreEqual(existingEvent, storedEvent);
        }
    }
}
