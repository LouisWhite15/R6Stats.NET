using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using R6Stats.NET.Authentication;
using R6Stats.NET.Filters;
using R6Tab.NET;

namespace R6Stats.NET
{
    public class Startup
    {
        private readonly string AllowSpecificOrigins = "AllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<UnhandledExceptionFilter>();
            });
            services.AddScoped<IR6TabApi, R6TabApi>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                        .WithOrigins(Configuration.GetValue<string>("AllowedOrigin"))
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                                  });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            var productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            var displayVersion = $"v{productVersion}";

            // Api Documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "R6Stats.NET",
                    Version = displayVersion
                });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("ApiKeyAuth", new OpenApiSecurityScheme
                {
                    Description = "API Key Authentication",
                    Name = "X-API-KEY",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKeyAuth"
                            }
                        },
                        new[] { string.Empty }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "R6Stats.NET");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
