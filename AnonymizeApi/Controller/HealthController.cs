using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/*
 * https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1
 */
namespace AnonymizeApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HealthController>();
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogInformation("Health");
            return "Success";
        }
    }
}