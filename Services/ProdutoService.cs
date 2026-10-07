namespace ProjetoAPI.Services;
using ProjetoAPI.Repositories;  
using ProjetoAPI.Models;
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _repository.ListarTodosAsync();
    }
    public async Task<Produto?> BuscarIDAsync(int id)
    {
        return await _repository.BuscarIDAsync(id);
    }
    public async Task<Produto> AdicionarProdutoAsync(Produto produto)
    {
        if(produto.Preco <= 0.01m)
            throw new ArgumentException("O preço do produto não pode ser negativo.");
        if(await _repository.ExisteProdutoAsync(produto.Nome))
            throw new ArgumentException("Já existe um produto com esse nome.");
        
        return await _repository.AdicionarProdutoAsync(produto);
    }
    public async Task<Produto?> AtualizarProdutoAsync(int id, Produto produtoAtualizado)
    {
        return await _repository.AtualizarProdutoAsync(id, produtoAtualizado);
    }
    public async Task<bool> ExcluirProdutoAsync(int id)
    {
        return await _repository.ExcluirProdutoAsync(id);
    }
    
}