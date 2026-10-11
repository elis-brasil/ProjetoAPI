using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.Models;

namespace ProjetoAPI.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Produto>> ListarTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
 
    }
    public async Task<Produto?> BuscarIDAsync(int id)
    {
        return await _context.Produtos.FindAsync(id);
    }
    public async Task<Produto> AdicionarProdutoAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
    public async Task<Produto?> AtualizarProdutoAsync(int id, Produto produtoAtualizado)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;  
        produto.Quantidade = produtoAtualizado.Quantidade;
        await _context.SaveChangesAsync();
        return produto;
    }
    public async Task<bool> ExcluirProdutoAsync(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return false;
        _context.Produtos.Remove(produto);    
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ExisteProdutoAsync(string nome)
    {
        return await _context.Produtos.AnyAsync(p => p.Nome == nome);
    }
}