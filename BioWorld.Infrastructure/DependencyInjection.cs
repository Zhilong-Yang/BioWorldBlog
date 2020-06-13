using System.Linq;
using System.Reflection;
using BioWorld.Application.Common.Interface;
using BioWorld.Infrastructure.Identity;
using BioWorld.Infrastructure.Repository;
using BioWorld.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BioWorld.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
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

            services.AddTransient<IDateTime, DateTimeService>();

            // services.AddScoped(typeof(IRepository<>), typeof(DbContextRepository<>));
            //
            // services.AddScoped<ITagRepoService>(c => new TagRepoService());

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            // services.AddScoped(typeof(IRepository<>), typeof(DbContextRepository<>));
            //
            // var asm = Assembly.GetAssembly(typeof(ApplicationService));
            // if (null != asm)
            // {
            //     var types = asm.GetTypes().Where(t => t.IsClass && t.IsPublic && t.Name.EndsWith("RepoService"));
            //     foreach (var t in types)
            //     {
            //         services.AddScoped(t, t);
            //     }
            // }
            
            return services;
        }
    }
}
