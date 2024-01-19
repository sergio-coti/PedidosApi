using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Dtos
{
    public class DadosPedidoDto
    {
        public Guid? CodigoPedido { get; set; }
        public DateTime DataHoraPedido { get; set; }
        public string? NomeCliente { get; set; }
        public decimal? Valor { get; set; }
        public string? StatusPedido { get; set; }
        public string? Observacoes { get; set; }
    }
}
