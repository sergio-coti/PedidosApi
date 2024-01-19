using Microsoft.EntityFrameworkCore;
using PedidosApi.Domain.Entities;
using PedidosApi.Domain.Interfaces.Repositories;
using PedidosApi.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext? _dataContext;

        public PedidoRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(Pedido pedido, Pagamento pagamento)
        {
            var transaction = _dataContext?.Database.BeginTransaction();

            await _dataContext.Pedido.AddAsync(pedido);
            await _dataContext.Pagamento.AddAsync(pagamento);
            await _dataContext.SaveChangesAsync();

            transaction.Commit();
        }

        public async Task<Pedido> Find(Guid codigoPedido)
        {
            return await _dataContext.Pedido
                .Include(p => p.Pagamento) //JOIN
                .FirstOrDefaultAsync(p => p.CodigoPedido.Equals(codigoPedido));
        }
    }
}
