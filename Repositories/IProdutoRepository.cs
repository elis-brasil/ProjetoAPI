namespace ProjetoAPI.Repositories;

using ProjetoAPI.Models;

public interface IProdutoRepository
{
    Task<List<Produto>> ListarTodosAsync(); 
    Task<Produto?> BuscarIDAsync(int id); 
    Task<Produto> AdicionarAsync(Produto produto); 
    Task<Produto?>AtualizarProdutoAsync(int id,Produto produtoAtualizado) ; 
    Task<bool> ExcluirProdutoAsync(int id); 
}



