﻿using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Web.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation
                                     .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
