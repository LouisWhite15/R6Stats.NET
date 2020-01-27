using Microsoft.AspNetCore.Mvc;
using R6Tab.NET.Models;

namespace R6Stats.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class R6StatsController : ControllerBase
    {
        [HttpGet("playerByNameAndPlatform")]
        public NameResults GetPlayerByNameAndPlatform()
        {
            // TODO: Flesh out endpoint
            return new NameResults();
        }
    }
}
