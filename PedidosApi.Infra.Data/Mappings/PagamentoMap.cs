using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Infra.Data.Mappings
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ValorProcessamento)
                .HasPrecision(10, 2);

            builder.HasOne(p => p.Pedido) //Pagamento TEM 1 Pedido
                .WithOne(p => p.Pagamento) //Pedido TEM 1 Pagamento
                .HasForeignKey<Pagamento>(p => p.PedidoId); //Chave estrangeira
        }
    }
}
