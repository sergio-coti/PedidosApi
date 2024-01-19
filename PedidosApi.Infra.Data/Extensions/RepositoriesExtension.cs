using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedidosApi.Domain.Interfaces.Repositories;
using PedidosApi.Infra.Data.Contexts;
using PedidosApi.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Data.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("PedidosApi")));

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
