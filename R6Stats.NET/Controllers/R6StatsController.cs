using Microsoft.AspNetCore.Mvc;
using R6Tab.NET;
using R6Tab.NET.Models;

namespace R6Stats.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class R6StatsController : ControllerBase
    {
        private readonly IR6TabApi _r6TabApi;

        public R6StatsController(IR6TabApi r6TabApi)
        {
            _r6TabApi = r6TabApi;
        }

        [HttpGet("playerByNameAndPlatform")]
        public NameResults GetPlayerByNameAndPlatform()
        {
            return _r6TabApi.GetPlayerWithNameAndPlatform("EldoubleU.", Platform.Uplay).Result;
        }
    }
}
