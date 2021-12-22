using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VL.Core.Domain;
using VL.Core.Shared.ModelView.Produto;
using VL.Manager.Interfaces.Manager;

namespace VL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoManager produto;

        public ProdutoController(IProdutoManager produto)
        {
            this.produto = produto;
        }

        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await produto.GetProdutosAsync());
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await produto.GetProdutoAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoProduto novoProduto)
        {
            var produtoInserido = await produto.InsertProdutoAsync(novoProduto);
            return CreatedAtAction(nameof(Get), new { id = produtoInserido.Id }, produtoInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlterarProduto alterProduto)
        {
            var produtoActualizado = await produto.UpdateProdutoAsync(alterProduto);
            if (produtoActualizado == null)
            {
                return NotFound();
            }
            return Ok(produtoActualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await produto.DeleteProdutoAsync(id);
            return NoContent();
        }
    }
}