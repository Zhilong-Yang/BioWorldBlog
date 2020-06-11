using System;
using System.Collections.Generic;
using System.Text;
using BioWorld.Application.Common.Interface;
using BioWorld.Infrastructure.Identity;
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
                services.AddDbContext<BlogDbContext>(options =>
                    options.UseInMemoryDatabase("BioWorldBlog"));
            }
            else
            {
                services.AddDbContext<BlogDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("ConnectionStrings"),
                        b => b.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName)));
            }

            services.AddScoped<IBlogDbContext>(provider => provider.GetService<BlogDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, BlogDbContext>();
            
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
