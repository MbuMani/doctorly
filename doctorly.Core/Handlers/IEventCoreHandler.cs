using doctorly.Core.Models;

namespace doctorly.Core.Handlers
{
    public interface IEventCoreHandler
    {
        ExternalEventContract CreateEvent(ExternalEventContract externalEventContract);

        ExternalEventContract UpdateEvent(ExternalEventContract externalEventContract);

        void DeleteEvent(ExternalEventContract externalEventContract);

        List<ExternalEventContract> GetEvents();
    }
}
