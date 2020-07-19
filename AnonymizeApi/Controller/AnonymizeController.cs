using AnonymizeApi.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnonymizeApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AnonymizeController : ControllerBase
    {
        private ILogger<AnonymizeController> _logger;
        private readonly IAnonymizer _anonymizer;

        public AnonymizeController(ILogger<AnonymizeController> logger, IAnonymizer anonymizer)
        {
            _logger = logger;
            _anonymizer = anonymizer;
        }

        [HttpGet]
        public ActionResult Anonymize([FromQuery] string url)
        {
            return Ok(_anonymizer.AnonymizeNamesInHtmlContent(url));
        }
    }
}