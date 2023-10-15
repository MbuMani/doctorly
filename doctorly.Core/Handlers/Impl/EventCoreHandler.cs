using AutoMapper;
using doctorly.Core.Models;
using doctorly.Persistence.Managers;
using doctorly.Persistence.Models;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("doctorly.Tests")]
namespace doctorly.Core.Handlers.Impl
{
    // Made this class public because i was struggling this it's visibility on the tests.
    public class EventCoreHandler : IEventCoreHandler
    {
        private readonly IEventManager _eventManager;
        private readonly IMapper _mapper;
        private readonly ILogger<EventCoreHandler> _logger;

        public EventCoreHandler(IEventManager eventManager, IMapper mapper, ILogger<EventCoreHandler> logger)
        {
            _eventManager = eventManager;
            _mapper = mapper;
            _logger = logger;
        }

        public ExternalEventContract CreateEvent(ExternalEventContract externalEventContract)
        {
            var source = $"{nameof(EventCoreHandler)}.{nameof(CreateEvent)}";
            try
            {
                var newEvent = _mapper.Map<Event>(externalEventContract);
                var savedEvent = _eventManager.CreateEvent(newEvent);

                return _mapper.Map<ExternalEventContract>(savedEvent);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to save [{nameof(externalEventContract)}] with title [{externalEventContract.Title}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public void DeleteEvent(ExternalEventContract externalEventContract)
        {
            var source = $"{nameof(EventCoreHandler)}.{nameof(DeleteEvent)}";
            try
            {
                var existingEvent = _mapper.Map<Event>(externalEventContract);

                _eventManager.DeleteEvent(existingEvent);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to save [{nameof(externalEventContract)}] with title [{externalEventContract.Title}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public List<ExternalEventContract> GetEvents()
        {
            var source = $"{nameof(EventCoreHandler)}.{nameof(GetEvents)}";
            try
            {
                var externalEvents = _eventManager.GetEvents();

                return _mapper.Map<List<ExternalEventContract>>(externalEvents);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to retrieve [{nameof(ExternalEventContract)}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }

        public ExternalEventContract UpdateEvent(ExternalEventContract externalEventContract)
        {
            var source = $"{nameof(EventCoreHandler)}.{nameof(UpdateEvent)}";
            try
            {
                var eventToUpdate = _mapper.Map<Event>(externalEventContract);
                var updatedEvent = _eventManager.UpdateEvent(eventToUpdate);

                return _mapper.Map<ExternalEventContract>(updatedEvent);
            }
            catch (Exception exception)
            {
                var errorMessage = $"[{source}]: Something went wrong while trying to save [{nameof(externalEventContract)}] with title [{externalEventContract.Title}]. [{exception.Message}]";
                _logger.LogError(errorMessage, exception);
                throw;
            }
        }
    }
}
