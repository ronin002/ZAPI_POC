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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ZurichController> _logger;

        public ZurichController(ILogger<ZurichController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProcess")]
        public IEnumerable<ZProcess> Get()
        {
            string[] processName = { "Process 1", "Process 2", "Process 3", "Process 4", "Process 5" };
            string[] processDescription = { "Description 1", "Description 2", "Description 3", "Description 4", "Description 5" };
            string[] processSummary = { "Summary 1", "Summary 2", "Summary 3", "Summary 4", "Summary 5" };

            IEnumerable<ZProcess> processes = new List<ZProcess>();
            foreach (var i in Enumerable.Range(1, 5))
            {
                ZProcess process = new ZProcess();
                process.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));
                process.Name = processName[i - 1];
                process.Description = processDescription[i - 1];
                process.Summary = processSummary[i - 1];
                processes.Append(process);
            }
             
            return processes.ToArray();
        }
    }
}
