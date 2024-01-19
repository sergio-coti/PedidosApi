using PedidosApi.Domain.Entities;
using PedidosApi.Domain.Interfaces.Events;
using PedidosApi.Domain.Interfaces.Repositories;
using PedidosApi.Domain.Interfaces.Services;
using PedidosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Services
{
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IPedidoRepository? _pedidoRepository;
        private readonly IPedidoCriadoEvent? _pedidoCriadoEvent;

        public PedidoDomainService(IPedidoRepository? pedidoRepository, IPedidoCriadoEvent? pedidoCriadoEvent)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoCriadoEvent = pedidoCriadoEvent;
        }

        public async Task<Pedido> Criar(Pedido pedido)
        {            
            #region Cadastrar o pedido

            await _pedidoRepository?.Add(pedido, pedido.Pagamento);

            #endregion

            #region Enviar o pedido para pagamento

            var model = new PedidoCriadoModel
            {
                PedidoId = pedido.Id,
                Valor = pedido.Valor,
                NumeroCartao = pedido.Pagamento.NumeroCartao,
                NomeTitular = pedido.Pagamento.NomeTitular,
                CodigoSeguranca = pedido.Pagamento.CodigoSeguranca,
                DataExpiracao = pedido.Pagamento.DataExpiracao
            };

            await _pedidoCriadoEvent.RealizarPagamento(model);

            #endregion

            return pedido;
        }

        public async Task<Pedido> Consultar(Guid codigoPedido)
        {
            return await _pedidoRepository.Find(codigoPedido);
        }
    }
}
