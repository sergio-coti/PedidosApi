using Microsoft.EntityFrameworkCore;
using PedidosApi.Domain.Entities;
using PedidosApi.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
    }
}
