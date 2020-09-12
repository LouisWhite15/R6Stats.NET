using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R6Stats.NET.Constants;

namespace R6Stats.NET.ServiceCollectionExtensions
{
    public static class AzureAdAuthentication
    {
        public static IServiceCollection AddAzureAdJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
            // By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
            // 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles'
            // This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(AzureADDefaults.JwtBearerAuthenticationScheme)
                    .AddAzureADBearer(options => configuration.Bind("AzureAd", options));

            // Change the authentication configuration  to accommodate the Microsoft identity platform endpoint.
            services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
            {
                options.TokenValidationParameters.RoleClaimType = "roles";

                // Reinitialize the options as this has changed to JwtBearerOptions to pick configuration values for attributes unique to JwtBearerOptions
                configuration.Bind("AzureAd", options);

                var azureAdOptions = new AzureADOptions();
                configuration.Bind("AzureAd", azureAdOptions);

                // This is an Microsoft identity platform Web API
                options.Authority += "/v2.0";

                options.TokenValidationParameters.ValidIssuers = new string[]
                {
                    $"https://login.microsoftonline.com/{azureAdOptions.TenantId}/",
                    $"https://login.windows.net/{azureAdOptions.TenantId}/",
                    $"https://login.microsoft.com/{azureAdOptions.TenantId}/",
                    $"https://sts.windows.net/{azureAdOptions.TenantId}/",
                    $"https://{azureAdOptions.Domain}/{azureAdOptions.TenantId}/"
                };

                // The valid audiences are both the Client ID (options.Audience) and api://{ClientID}
                options.TokenValidationParameters.ValidAudiences = new string[] { options.Audience, $"api://{options.Audience}" };

                // When an access token for our own Web API is validated, we add it to MSAL.NET's cache so that it can
                // be used from the controllers.
                options.Events = new JwtBearerEvents();

                options.Events.OnTokenValidated = async context =>
                {
                    // This check is required to ensure that the Web API only accepts tokens from tenants where it has been consented and provisioned.
                    if (!context.Principal.Claims.Any(x => x.Type == ClaimKeyConstants.Scope || x.Type == "scp")
                       && !context.Principal.Claims.Any(y => y.Type == ClaimKeyConstants.Roles))
                    {
                        throw new UnauthorizedAccessException("Neither scope or roles claim was found in the bearer token.");
                    }

                    await Task.FromResult(0);
                };
            });

            return services;
        }
    }
}