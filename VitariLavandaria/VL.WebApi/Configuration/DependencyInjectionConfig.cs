﻿using Microsoft.Extensions.DependencyInjection;
using VL.Data.Repository;
using VL.Manager.Implementation;
using VL.Manager.Interfaces;

namespace VL.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICargoManager, CargoManager>();
        }
    }
}