using ExemploCqrs.Aplicacao.Recursos.Pedidos.AdicionarPedido;
using ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos;
using ExemploCqrs.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExemploCqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register a new order for a Customer
        /// </summary>
        /// <param name="command">Order details</param>
        /// <param name="cancellationToken"></param>
        /// <returns>204, no content</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(422, Type = typeof(DefaultErrorResponse))]
        [ProducesResponseType(404, Type = typeof(DefaultErrorResponse))]
        public async Task<IActionResult> Create(AdicionarPedidoCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery]ListarPedidosQuery query, CancellationToken cancellationToken)
        {
            var pedidos = await _mediator.Send(query, cancellationToken);
            return Ok(pedidos);
        }
    }
}
