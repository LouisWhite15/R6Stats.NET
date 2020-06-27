using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;

namespace R6Stats.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitorController : ControllerBase
    {
        [HttpGet]
        public long Ping()
        {
            Ping pinger = null;
            long ping = 0;

            try
            {
                pinger = new Ping();
                var reply = pinger.Send("8.8.8.8");
                ping = reply.RoundtripTime;

            }
            catch(PingException)
            {
                // Discard ping exceptions
            }
            finally
            {
                if (pinger != null)
                    pinger.Dispose();
            }

            return ping;
        }
    }
}
