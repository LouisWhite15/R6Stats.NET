using System;
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

        [HttpGet("player")]
        public NameResults GetPlayerByNameAndPlatform()
        {
            return _r6TabApi.GetPlayerByNameAndPlatform("EldoubleU.", Platform.Uplay).Result;
        }

        [HttpGet("player/{playerId}")]
        public PlayerDataResults GetPlayerById(Guid playerId)
        {
            return _r6TabApi.GetPlayerById(playerId).Result;
        }
    }
}
