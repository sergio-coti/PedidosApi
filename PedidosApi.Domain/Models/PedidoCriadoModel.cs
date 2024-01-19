using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Models
{
    public class PedidoCriadoModel
    {
        public Guid? PedidoId { get; set; }
        public string? NumeroCartao { get; set; }
        public string? NomeTitular { get; set; }
        public string? DataExpiracao { get; set; }
        public string? CodigoSeguranca { get; set; }
        public decimal? Valor { get; set; }
    }
}
