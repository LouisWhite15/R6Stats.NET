using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using R6Tab.NET;
using R6Tab.NET.Models;

namespace R6Stats.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowSpecificOrigins")]
    public class R6StatsController : ControllerBase
    {
        private readonly IR6TabApi _r6TabApi;
        private readonly string _r6TabApiKey;

        public R6StatsController(
            IR6TabApi r6TabApi,
            IConfiguration configuration)
        {
            _r6TabApi = r6TabApi;
            _r6TabApiKey = configuration.GetValue<string>("R6Tab_ApiKey");
        }

        [HttpGet("search/{platform}/{name}")]
        public async Task<IActionResult> GetPlayerByNameAndPlatformAsync(string platform, string name)
        {
            Enum.TryParse(platform, ignoreCase: true, out Platform parsedPlatform);

            if (parsedPlatform == Platform.None)
            {
                return BadRequest();
            }

            var result = await _r6TabApi.SearchByName(name, parsedPlatform, _r6TabApiKey);
            return Ok(result);
        }

        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetPlayerByIdAsync(Guid id)
        {
            var result = await _r6TabApi.SearchById(id, _r6TabApiKey);
            return Ok(result);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdatePlayerByIdAsync(Guid id)
        {
            await _r6TabApi.UpdatePlayerDataById(id, _r6TabApiKey);
            return Ok();
        }
    }
}
