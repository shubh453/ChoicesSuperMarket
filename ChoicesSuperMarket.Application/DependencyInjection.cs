using AutoMapper;
using ChoicesSuperMarket.Application.Common.Behaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChoicesSuperMarket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            return services;
        }
    }
}