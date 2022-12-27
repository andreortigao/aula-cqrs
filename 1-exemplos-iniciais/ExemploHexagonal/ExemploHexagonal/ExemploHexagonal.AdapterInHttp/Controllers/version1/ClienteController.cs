using ExemploHexagonal.Domain.Clientes.PortasEntrada;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExemploHexagonal.AdapterInHttp.Controllers.version1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _productService;

        public ClienteController(IClienteService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        [Route("{productId:int}")]
        public IActionResult Get([FromRoute, Required] int productId)
        {
            var response = this._productService.Ler(productId);
            return Ok(response);
        }
    }
}
