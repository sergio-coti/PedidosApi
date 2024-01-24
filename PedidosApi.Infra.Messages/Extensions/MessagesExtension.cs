using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PedidosApi.Domain.Interfaces.Events;
using PedidosApi.Infra.Messages.Events;
using PedidosApi.Infra.Messages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Messages.Extensions
{
    public static class MessagesExtension
    {
        public static IServiceCollection AddMessages(this IServiceCollection services, IConfiguration configuration)
        {
            //Capturando as configurações do /appsettings.json
            var rabbitMQSettings = new RabbitMQSettings();
            new ConfigureFromConfigurationOptions<RabbitMQSettings>
                (configuration.GetSection("RabbitMQSettings")).Configure(rabbitMQSettings);

            services.AddSingleton(rabbitMQSettings);
            services.AddTransient<IPedidoCriadoEvent, PedidoCriadoEvent>();

            return services;
        }
    }
}
