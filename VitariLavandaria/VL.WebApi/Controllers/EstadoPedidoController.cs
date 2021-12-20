using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView;
using VL.Manager.Interfaces;

namespace VL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPedidoController : ControllerBase
    {
        private readonly IEstadoPedidoManager estado;

        public EstadoPedidoController(IEstadoPedidoManager estado)
        {
            this.estado = estado;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EstadoPedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await estado.GetEstadoPedidosAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstadoPedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await estado.GetEstadoPedidoAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(EstadoPedido), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoEstadoPedido novoEstado)
        {
            var estadoInserido = await estado.InsertEstadoPedidoAsync(novoEstado);
            return CreatedAtAction(nameof(Get), new { id = estadoInserido.Id }, estadoInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EstadoPedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarEstadoPedido alterEstado)
        {
            var estadoActualizado = await estado.UpdateEstadoPedidoAsync(alterEstado);
            if (estadoActualizado == null)
            {
                return NotFound();
            }
            return Ok(estadoActualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EstadoPedido), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await estado.DeleteEstadoPedidoAsync(id);
            return NoContent();
        }
    }
}