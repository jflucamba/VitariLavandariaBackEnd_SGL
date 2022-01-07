using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Pedido;
using VL.Manager.Interfaces.Manager;

namespace VL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoManager manager;

        public PedidoController(IPedidoManager manager)
        {
            this.manager = manager;
        }

        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetPedidosAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetPedidoAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoPedido novoPedido)
        {
            var pedidoInserido = await manager.InsertPedidoAsync(novoPedido);
            return CreatedAtAction(nameof(Get), new { id = pedidoInserido.Id }, pedidoInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarPedido alterPedido)
        {
            var pedidoActualizado = await manager.UpdatePedidoAsync(alterPedido);
            if (pedidoActualizado == null)
            {
                return NotFound();
            }
            return Ok(pedidoActualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await manager.DeletePedidoAsync(id);
            return NoContent();
        }
    }
}