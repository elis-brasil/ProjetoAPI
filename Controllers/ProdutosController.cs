using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static readonly List<Produto> Produtos = new List<Produto>
    {
       new Produto { Id = 1, Nome = "Produto 1", Preco = 10.99m, Quantidade = 5 },
       new Produto { Id = 2, Nome = "Produto 2", Preco = 19.99m, Quantidade = 3 }, 
       new Produto { Id = 3, Nome = "Produto 3", Preco = 5.99m, Quantidade = 10 },
    };

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(Produtos);
    }
    [HttpGet("{id}")]
    public IActionResult BuscarID(int id)
    {
        if(id <=0)
        {
            return BadRequest("ID não pode ser negativo");
        }
        var produto = Produtos.FirstOrDefault(p => p.Id == id);
        if(produto == null)
        {
            return NotFound($"Produto com ID {id} não encontrado");
        }

        return Ok(produto);
    }

    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] Produto produto)
    {
        if(produto == null || string.IsNullOrWhiteSpace(produto.Nome))
        {
            return BadRequest("Nome do produto não pode ser vazio");
        }
        Produtos.Add(produto);
        return Ok($"Produto {produto.Nome} adicionado com sucesso");
    }

}
