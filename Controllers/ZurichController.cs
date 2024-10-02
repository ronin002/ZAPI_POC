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

        [AllowAnonymous]
        [HttpGet("api/v1/zurich/")]
        public IActionResult GetListTest()
        {
            List<ZUser> users = new List<ZUser>();

            ZUser user = new ZUser();
            user.Name = "Edson";
            user.Idade = 30;

            ZUser user1= new ZUser();
            user1.Name = "Marcos";
            user1.Idade = 27;


            ZUser user2 = new ZUser();
            user2.Name = "Felipe";
            user2.Idade = 22;


            users.Add(user);
            users.Add(user1);
            users.Add(user2);

            return Ok(users);
        }
    }

    public class ZUser
    {
        public string Name { get; set; }
        public int Idade { get; set; }
    }
}
