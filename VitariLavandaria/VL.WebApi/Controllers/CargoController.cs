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
    public class CargoController : ControllerBase
    {
        private readonly ICargoManager cargo;

        public CargoController(ICargoManager cargo)
        {
            this.cargo = cargo;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await cargo.GetCargosAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await cargo.GetCargoAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCargo novoCargo)
        {
            var cargoInserido = await cargo.InsertCargoAsync(novoCargo);
            return CreatedAtAction(nameof(Get), new { id = cargoInserido.Id }, cargoInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarCargo alterCargo)
        {
            var cargoActualizado = await cargo.UpdateCargoAsync(alterCargo);
            if (cargoActualizado == null)
            {
                return NotFound();
            }
            return Ok(cargoActualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cargo), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await cargo.DeleteCargoAsync(id);
            return NoContent();
        }
    }
}