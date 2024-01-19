using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Dtos
{
    public class CriarPedidoDto
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public CriarPagamentoDto? Pagamento { get; set; }
    }
}
