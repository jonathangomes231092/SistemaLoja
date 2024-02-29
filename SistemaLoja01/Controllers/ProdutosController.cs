using Microsoft.AspNetCore.Mvc;
using Sistem.Application.Commands.ProdutosCommands;
using Sistem.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SistemaLoja01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
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
        public async Task<IActionResult> DeleteProduto(int id)
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
        public IActionResult GetProduto(int id)
        {
            return Ok();
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            return Ok();
        }
    }
}
