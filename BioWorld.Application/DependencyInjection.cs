﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace BioWorld.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
