using Microsoft.AspNetCore.Mvc;

namespace doctorly.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
