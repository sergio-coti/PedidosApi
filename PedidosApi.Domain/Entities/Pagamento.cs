using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Entities
{
    public class Pagamento
    {
        public Guid? Id { get; set; }
        public string? NumeroCartao { get; set; }
        public string? NomeTitular { get; set; }
        public string? DataExpiracao { get; set; }
        public string? CodigoSeguranca { get; set; }
        public bool? Processado { get; set; }
        public DateTime? DataHoraProcessamento { get; set; }
        public Guid? CodigoProcessamento { get; set; }
        public decimal? ValorProcessamento { get; set; }
        public Guid? PedidoId { get; set; }

        #region Relacionamentos

        public Pedido? Pedido { get; set; }

        #endregion
    }
}
