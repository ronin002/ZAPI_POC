using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ZurichAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ZurichController : ControllerBase
    {
       
        private readonly ILogger<ZurichController> _logger;

        public ZurichController(ILogger<ZurichController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "api/v1/zurich/{id}")]
        public IEnumerable<ZProcess> Get(FromQueryAttribute idProposta)
        {
            return null;
        }
    }
}
