using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;


namespace ProjetoAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet] 
    public async Task<IActionResult> ListarTodos()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return Ok(produtos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarID(int id)
    {
        if(id <=0)
        {
            return BadRequest("ID não pode ser negativo");
        }
        var produto = await _context.Produtos.FindAsync(id);
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
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return Ok($"Produto {produto.Nome} adicionado com sucesso");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)
    {
 
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;  
        produto.Quantidade = produtoAtualizado.Quantidade;
   
        await _context.SaveChangesAsync();
        return Ok($"Produto {produto.Nome} atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }

        _context.Produtos.Remove(produto);    
        await _context.SaveChangesAsync();

        return Ok($"Produto {produto.Nome} excluído com sucesso");
    }

}
