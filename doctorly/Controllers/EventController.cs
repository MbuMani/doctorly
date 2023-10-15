using doctorly.Api.Controllers.Base;
using doctorly.Core.Handlers;
using doctorly.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace doctorly.Api.Controllers
{
    public class EventController : ApiControllerBase
    {
        [HttpPost]
        [Route(nameof(CreateEvent))]
        [Produces(typeof(ExternalEventContract))]
        public IActionResult CreateEvent([FromServices] IEventCoreHandler handler, ExternalEventContract externalEventContract)
        {
            var result = handler.CreateEvent(externalEventContract);
            return Ok(result);
        }

        [HttpPost]
        [Route(nameof(UpdateEvent))]
        [Produces(typeof(ExternalEventContract))]
        public IActionResult UpdateEvent([FromServices] IEventCoreHandler handler, ExternalEventContract externalEventContract)
        {
            var result = handler.UpdateEvent(externalEventContract);
            return Ok(result);
        }

        [HttpPost]
        [Route(nameof(DeleteEvent))]
        [Produces(typeof(ExternalEventContract))]
        public IActionResult DeleteEvent([FromServices] IEventCoreHandler handler, ExternalEventContract externalEventContract)
        {
            handler.DeleteEvent(externalEventContract);
            return Ok();
        }

        [HttpGet]
        [Route(nameof(GetEvents))]
        [Produces(typeof(ExternalEventContract))]
        public IActionResult GetEvents([FromServices] IEventCoreHandler handler)
        {
            var results = handler.GetEvents();
            return Ok(results);
        }
    }
}
