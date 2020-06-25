using BioWorld.Application;
using BioWorld.Application.Common.Interface;
using BioWorld.Infrastructure.Identity;
using BioWorld.Infrastructure.Services;
using BioWorld.Infrastructure.Services.WordFilter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BioWorld.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("BioWorldBlogDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddSingleton<IBlogConfigService, BlogConfigService>();

            services.AddScoped<IDateTime>(c => new DateTimeService(AppSettings.Instance.TimeZoneUtcOffset));

            services.AddScoped<IMaskWordFilter>(c => new MaskWordFilter(new StringWordSource(AppSettings.Instance.DisharmonyWords)));
            
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}