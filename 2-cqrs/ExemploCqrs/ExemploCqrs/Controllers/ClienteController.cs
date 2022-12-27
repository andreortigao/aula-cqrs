using ExemploCqrs.Aplicacao.Recursos.Clientes.AdicionarNovoCliente;
using ExemploCqrs.Aplicacao.Recursos.Clientes.LerDetalhesCliente;
using ExemploCqrs.Aplicacao.Recursos.Clientes.ListarClientes;
using ExemploCqrs.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExemploCqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a new Customer
        /// </summary>
        /// <param name="command">Customer information</param>
        /// <param name="cancellationToken"></param>
        /// <returns>204, no content</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(422, Type = typeof(DefaultErrorResponse))]
        public async Task<IActionResult> Create(AdicionarNovoClienteCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Returns a list of registered customers
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of <see cref="ClienteModel"/></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClienteModel>))]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new ListarClientesQuery(), cancellationToken);
            return Ok(customers);
        }

        /// <summary>
        /// Returns a single customer details with their orders
        /// </summary>
        /// <param name="customerId">Customer unique identifier</param>
        /// <param name="cancellationToken"></param>
        /// <returns>One <see cref="ClienteDetalhes"/> with a list of <see cref="PedidoDetalhes" /></returns>
        [HttpGet("{customerId:int}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClienteModel>))]
        [ProducesResponseType(422, Type = typeof(DefaultErrorResponse))]
        [ProducesResponseType(404, Type = typeof(DefaultErrorResponse))]
        public async Task<IActionResult> GetDetails(int customerId, CancellationToken cancellationToken)
        {
            var query = new LerDetalhesClienteQuery { ClienteId = customerId };
            var customer = await _mediator.Send(query, cancellationToken);
            return Ok(customer);
        }
    }
}
