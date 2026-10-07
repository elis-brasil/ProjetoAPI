using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;
using ProjetoAPI.Services;

namespace ProjetoAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet] 
    public async Task<IActionResult> ListarTodos()
    {
        var produtos = await _service.ListarTodosAsync();
        return Ok(produtos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarID(int id)
    {
        if(id <=0)
        {
            return BadRequest("ID não pode ser negativo");
        }
        var produto = await _service.BuscarIDAsync(id);
        if(produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarProduto([FromBody] Produto produto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var produtoAdicionado = await _service.AdicionarProdutoAsync(produto);
            return Ok($"Produto {produtoAdicionado.Nome} adicionado com sucesso");
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Erro ao adicionar o produto: {ex.Message}");
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)
    {
 
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var produto = await _service.BuscarIDAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }

        return Ok($"Produto {produto.Nome} atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirProduto(int id)
    {
        var removido = await _service.ExcluirProdutoAsync(id);

        if (!removido)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }
        return NoContent();
    }

}
