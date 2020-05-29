using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace R6Stats.NET.Authentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly string _requiredApiKey;
        private const string ApiKeyHeaderName = "X-API-KEY";

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration configuration)
            : base(options, logger, encoder, clock)
        {
            _requiredApiKey = configuration["ApiKey"];
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValue))
            {
                return await Task.FromResult(AuthenticateResult.Fail("No API Key provided in request header"));
            }

            if (apiKeyHeaderValue == _requiredApiKey)
            {
                var identity = new ClaimsIdentity("API Key");
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), null, Options.Scheme);
                return await Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return await Task.FromResult(AuthenticateResult.Fail("Invalid API key provided"));
        }
    }
}
