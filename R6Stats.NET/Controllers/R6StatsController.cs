using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using R6Tab.NET;
using R6Tab.NET.Models;

namespace R6Stats.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class R6StatsController : ControllerBase
    {
        private readonly IR6TabApi _r6TabApi;
        private readonly IConfiguration _configuration;

        public R6StatsController(
            IR6TabApi r6TabApi,
            IConfiguration configuration)
        {
            _r6TabApi = r6TabApi;
            _configuration = configuration;
        }

        [HttpGet("search/{platform}/{name}")]
        public async Task<IActionResult> GetPlayerByNameAndPlatformAsync(string platform, string name)
        {
            Enum.TryParse(platform, ignoreCase: true, out Platform parsedPlatform);

            if (parsedPlatform == Platform.None)
            {
                return BadRequest();
            }

            var result = await _r6TabApi.SearchByName(name, parsedPlatform, _configuration["R6Tab.ApiKey"]);
            return Ok(result);
        }

        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            var result = await _r6TabApi.SearchById(id, _configuration["R6Tab.ApiKey"]);
            return Ok(result);
        }
    }
}
