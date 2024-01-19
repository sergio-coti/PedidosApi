using PedidosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Interfaces.Services
{
    public interface IPedidoDomainService
    {
        Task<Pedido> Criar(Pedido pedido);
        Task<Pedido> Consultar(Guid codigoPedido);
    }
}
