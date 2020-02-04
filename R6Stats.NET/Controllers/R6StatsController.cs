using System;
using System.Threading.Tasks;
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

        [HttpGet("player/{platform}/{name}")]
        public async Task<IActionResult> GetPlayerByNameAndPlatformAsync(string platform, string name)
        {
            Enum.TryParse(platform, ignoreCase: true, out Platform parsedPlatform);

            if (parsedPlatform == Platform.None)
            {
                return BadRequest();
            }

            var result = await _r6TabApi.GetPlayerByNameAndPlatform(name, parsedPlatform);
            return Ok(result);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetPlayerByIdAsync(Guid playerId)
        {
            var result = await _r6TabApi.GetPlayerById(playerId);
            return Ok(result);
        }
    }
}
