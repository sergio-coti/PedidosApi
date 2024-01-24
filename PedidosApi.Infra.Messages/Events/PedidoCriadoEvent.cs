using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PedidosApi.Domain.Interfaces.Events;
using PedidosApi.Domain.Models;
using PedidosApi.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Messages.Events
{
    public class PedidoCriadoEvent : IPedidoCriadoEvent
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;

        public PedidoCriadoEvent(RabbitMQSettings? rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }

        /// <summary>
        /// Gravar os dados do pagamento na fila (Message Broker)
        /// </summary>
        public async Task RealizarPagamento(PedidoCriadoModel model)
        {
            var connectionFactory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings.Url) };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    #region Criando a fila

                    channel.QueueDeclare(
                        queue: _rabbitMQSettings.Queue,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: _rabbitMQSettings.Queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
                        );

                    #endregion
                }
            }
        }
    }
}
