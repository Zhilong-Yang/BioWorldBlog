using BioWorld.Application;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Configuration;
using BioWorld.BackEnd.Filters;
using BioWorld.BackEnd.Services;
using BioWorld.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd
{
    public class Startup
    {
        private ILogger<Startup> _logger;

        private readonly IConfigurationSection _appSettingsSection;

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _appSettingsSection = _configuration.GetSection(nameof(AppSettings));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var blogConfigurationSection = new BlogConfigSetting();
            _configuration.Bind(nameof(BlogConfigSetting), blogConfigurationSection);
            services.Configure<BlogConfigSetting>(_configuration.GetSection(nameof(BlogConfigSetting)));

            services.Configure<AppSettings>(_appSettingsSection);
            services.AddApplication();
            services.AddInfrastructure(_configuration);
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(option => option.Filters.Add(new ApiExceptionFilter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            ILogger<Startup> logger,
            IHostApplicationLifetime appLifetime,
            IWebHostEnvironment env)
        {
            _logger = logger;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            appLifetime.ApplicationStarted.Register(() =>
            {
                _logger.LogInformation("Application started.");
            });
            appLifetime.ApplicationStopping.Register(() =>
            {
                _logger.LogInformation("Application is stopping...");
            });
            appLifetime.ApplicationStopped.Register(() =>
            {
                _logger.LogInformation("Application stopped.");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}