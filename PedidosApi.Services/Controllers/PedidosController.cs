using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApi.Application.Dtos;
using PedidosApi.Application.Interfaces;

namespace PedidosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAppService? _pedidoAppService;

        public PedidosController(IPedidoAppService? pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(DadosPedidoDto), 201)]
        public async Task<IActionResult> Post([FromBody] CriarPedidoDto dto)
        {
            var result = await _pedidoAppService.Criar(dto);
            return StatusCode(201, result);
        }

        [HttpGet("consultar/{codigoPedido}")]
        [ProducesResponseType(typeof(DadosPedidoDto), 200)]
        public async Task<IActionResult> Get(Guid codigoPedido)
        {
            var result = await _pedidoAppService.Consultar(codigoPedido);
            return StatusCode(200, result);
        }
    }
}
