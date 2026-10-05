using System.ComponentModel.DataAnnotations;
namespace ProjetoAPI.Models;
public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do produto não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    public int Quantidade { get; set; }
}
