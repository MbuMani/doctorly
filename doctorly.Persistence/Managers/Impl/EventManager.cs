using doctorly.Persistence.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("doctorly.Tests")]
namespace doctorly.Persistence.Managers.Impl
{
    internal class EventManager : IEventManager
    {
        private readonly DoctorlyContext _doctorlyContext;

        public EventManager(DoctorlyContext doctorlyContext)
        {
            _doctorlyContext = doctorlyContext;
        }

        public Event CreateEvent(Event newEvent)
        {
            _doctorlyContext.Events.Add(newEvent);
            _doctorlyContext.SaveChanges();

            return newEvent;
        }

        public void DeleteEvent(Event existingEvent)
        {
            _doctorlyContext.Events.Remove(existingEvent);
            _doctorlyContext.SaveChanges();
        }

        public List<Event> GetEvents()
        {
            return _doctorlyContext.Events.ToList();
        }

        public Event UpdateEvent(Event existingEvent)
        {
            _doctorlyContext.Events.Update(existingEvent);
            _doctorlyContext.SaveChanges();

            return existingEvent;
        }
    }
}
