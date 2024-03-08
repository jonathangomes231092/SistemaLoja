using Microsoft.AspNetCore.Mvc;
using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Interfaces;
using Sistem.Infra.Data.SqlServer.Contexts;
using System.ComponentModel.DataAnnotations;

namespace SistemaLoja01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly SqlServerContext _sqlServerContext;

        public ProdutosController(IProdutoAppService produtoAppService, SqlServerContext sqlServerContext)
        {
            _produtoAppService = produtoAppService;
            _sqlServerContext = sqlServerContext;
        }

        [HttpPost("ResgistrarProduto")]
        public async Task<IActionResult> ResgistrarProduto(ProdutoCreateCommand command)
        {
            try
            {
                var produto = await _produtoAppService.Creat(command);
                return StatusCode(201, produto); //CRIANDO
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message); // bad request
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });// bad request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); // internal server error
            }
        }

        [HttpPut("EditarProduto")]
        public async Task<IActionResult> EditarProduto(ProdutoUpdateCommand command)
        {
            try
            {
                var produto = await _produtoAppService.Update(command);
                return StatusCode(200, produto); //ok
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Message); // bad request
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });// bad request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); // internal server error
            }
        }

        [HttpDelete("DeletarProduto/{id}")]
        public async Task<IActionResult> DeleteProduto(Guid id)
        {
            try
            {
                var command = new ProdutoDeleteCommand { Id = id };

                var produto = await _produtoAppService.Delete(command);
                return StatusCode(200, produto); //ok
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });// bad request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); // internal server error
            }
        }

        [HttpGet("ObterDetalhesDoProduto/{id}")]
        public IActionResult GetProduto(Guid id)
        {
            try
            {
                var produto = _sqlServerContext.Produtos.SingleOrDefault(d => d.Id == id);
                if (produto == null)
                    return NoContent();

                return StatusCode(200, produto);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });// bad request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); // internal server error
            }
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            try
            {
                // Verifica se os parâmetros de página e limite são válidos
                if (page <= 0 || limit <= 0)
                {
                    throw new ArgumentException("Page and limit must be greater than zero.");
                }

                // Calcula o índice inicial com base na página e no limite
                int startIndex = (page - 1) * limit;

                // Obtém os produtos paginados, ordenando por algum critério (por exemplo, por ID)
                var produtosPaginados = _sqlServerContext.Produtos
                    .OrderBy(p => p.Id) // Substitua "Id" pelo campo que deseja ordenar
                    .Skip(startIndex)
                    .Take(limit)
                    .ToList();

                // Faça o que precisar com os produtos paginados, por exemplo, retornar em um JSON
                return Ok(produtosPaginados);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });// bad request
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message }); // internal server error
            }
        }
    }
}
