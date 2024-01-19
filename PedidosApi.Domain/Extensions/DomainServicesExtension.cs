using Microsoft.Extensions.DependencyInjection;
using PedidosApi.Domain.Interfaces.Services;
using PedidosApi.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPedidoDomainService, PedidoDomainService>();

            return services;
        }
    }
}
