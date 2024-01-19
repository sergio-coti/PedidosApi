using PedidosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task Add(Pedido pedido, Pagamento pagamento);
        Task<Pedido> Find(Guid codigoPedido);
    }
}
