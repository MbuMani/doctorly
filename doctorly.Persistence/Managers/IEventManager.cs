using doctorly.Persistence.Models;

namespace doctorly.Persistence.Managers
{
    public interface IEventManager
    {
        Event CreateEvent(Event newEvent);

        Event UpdateEvent(Event existingEvent);

        void DeleteEvent(Event existingEvent);

        List<Event> GetEvents();
    }
}
