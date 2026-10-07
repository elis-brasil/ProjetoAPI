namespace ProjetoAPI.Services;
using ProjetoAPI.Models;
public interface IProdutoService
{
    Task<List<Produto>> ListarTodosAsync();
    Task<Produto?> BuscarIDAsync(int id);
    Task<Produto> AdicionarProdutoAsync(Produto produto);
    Task<Produto?> AtualizarProdutoAsync(int id, Produto produtoAtualizado);
    Task<bool> ExcluirProdutoAsync(int id);

}