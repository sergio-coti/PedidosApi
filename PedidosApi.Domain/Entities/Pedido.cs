using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Entities
{
    public class Pedido
    {
        public Guid? Id { get; set; }
        public Guid? CodigoPedido { get; set; }
        public DateTime DataHoraPedido { get; set; }
        public string? NomeCliente { get; set; }
        public decimal? Valor { get; set; }
        public string? StatusPedido { get; set; }
        public string? Observacoes { get; set; }

        #region Relacionamentos

        public Pagamento? Pagamento { get; set; }

        #endregion
    }
}
