using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Dtos
{
    public class CriarPagamentoDto
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? NumeroCartao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? NomeTitular { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? DataExpiracao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string? CodigoSeguranca { get; set; }
    }
}
