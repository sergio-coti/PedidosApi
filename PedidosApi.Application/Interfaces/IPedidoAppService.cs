using PedidosApi.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Application.Interfaces
{
    public interface IPedidoAppService
    {
        Task<DadosPedidoDto> Criar(CriarPedidoDto dto);
        Task<DadosPedidoDto> Consultar(Guid codigoPedido);
    }
}
