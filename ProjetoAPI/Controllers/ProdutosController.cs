using Microsoft.AspNetCore.Mvc;

namespace ProjetoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static readonly string[] Produtos = new[]
    {
    "Monitor", 
    "Mouse", 
    "Teclado", 
    "Headset",
    "Webcam",
    "Cadeira Gamer",
    "Mesa Gamer",
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
        if(id >= Produtos.Length)
        {
            return NotFound("Produto não encontrado");
        }
        return Ok($"Produto {id} encontrado, {Produtos[id-1]}");
    }
    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
        {
            return BadRequest("Nome do produto não pode ser vazio");
        }
        return Ok($"Produto {nome} adicionado com sucesso");
    }

}
