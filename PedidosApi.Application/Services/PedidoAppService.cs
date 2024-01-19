using PedidosApi.Application.Dtos;
using PedidosApi.Application.Interfaces;
using PedidosApi.Domain.Entities;
using PedidosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoDomainService _pedidoDomainService;

        public PedidoAppService(IPedidoDomainService pedidoDomainService)
        {
            _pedidoDomainService = pedidoDomainService;
        }

        public async Task<DadosPedidoDto> Criar(CriarPedidoDto dto)
        {
            var pedidoId = Guid.NewGuid();

            var pedido = new Pedido
            {
                Id = pedidoId,
                CodigoPedido = Guid.NewGuid(),
                DataHoraPedido = DateTime.Now,
                NomeCliente = dto.NomeCliente,
                Valor = dto.Valor,
                StatusPedido = "Aguardando pagamento",
                Observacoes = "Pedido realizado, aguardando pagamento.",
                Pagamento = new Pagamento
                {
                    Id = Guid.NewGuid(),
                    NumeroCartao = dto.Pagamento.NumeroCartao,
                    DataExpiracao = dto.Pagamento.DataExpiracao,
                    CodigoSeguranca = dto.Pagamento.CodigoSeguranca,
                    NomeTitular = dto.Pagamento.NomeTitular,
                    Processado = false,
                    PedidoId = pedidoId
                }
            };

            await _pedidoDomainService.Criar(pedido);

            var result = new DadosPedidoDto
            {
                CodigoPedido = pedido.CodigoPedido,
                DataHoraPedido = pedido.DataHoraPedido,
                NomeCliente = pedido.NomeCliente,
                Observacoes = pedido.Observacoes,
                StatusPedido = pedido.StatusPedido,
                Valor = pedido.Valor
            };

            return result;
        }

        public async Task<DadosPedidoDto> Consultar(Guid codigoPedido)
        {
            var pedido = await _pedidoDomainService.Consultar(codigoPedido);

            if(pedido != null)
            {
                var result = new DadosPedidoDto
                {
                    CodigoPedido = pedido.CodigoPedido,
                    DataHoraPedido = pedido.DataHoraPedido,
                    NomeCliente = pedido.NomeCliente,
                    Observacoes = pedido.Observacoes,
                    StatusPedido = pedido.StatusPedido,
                    Valor = pedido.Valor
                };

                return result;
            }

            return null;
        }
    }
}
