using Microsoft.Extensions.DependencyInjection;
using PedidosApi.Application.Interfaces;
using PedidosApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPedidoAppService, PedidoAppService>();

            return services;
        }
    }
}
