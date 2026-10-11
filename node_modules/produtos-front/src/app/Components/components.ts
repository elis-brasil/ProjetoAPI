import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutosService } from '../Services/produtos.service';
import { Produto } from '../Models/produto.model';

@Component({
  selector: 'app-components',
  standalone: true, 
  imports: [CommonModule, FormsModule],
  providers: [ProdutosService], 
  templateUrl: './components.html',
  styleUrl: './components.css',
})
export class Components implements OnInit {

  Produtos: Produto[] = [];
  
  // Objeto que espelha os campos do formulário
  currentProduct: Produto = { id: 0, nome: '', preco: 0, quantidade: 0 };
  isEditMode: boolean = false;

  constructor(private productService: ProdutosService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  // GET: Atualiza a lista na tela
  loadProducts(): void {
    this.productService.listarTodos().subscribe({
      next: (data) => this.Produtos = data,
      error: (err) => console.error('Erro ao buscar produtos', err)
    });
  }

   // POST / PUT: Salva as alterações
  saveProduct(): void {
    // Altere as chaves para Letra Maiúscula para bater com o padrão do C# / .NET
    const dadosProduto = {
      Nome: this.currentProduct.nome,
      Preco: this.currentProduct.preco,
      Quantidade: this.currentProduct.quantidade
    } as any;

    if (this.isEditMode && this.currentProduct.id) {
      this.productService.atualizar(this.currentProduct.id, dadosProduto).subscribe({
        next: () => {
          this.resetForm();
          this.loadProducts();
        },
        error: (err) => alert('Erro ao atualizar produto')
      });
    } else {
      this.productService.criar(dadosProduto).subscribe({
        next: () => {
          this.resetForm();
          this.loadProducts();
        },
        error: (err) => alert('Erro ao criar produto')
      });
    }
  }

  // DELETE: Remove o produto
  deleteProduct(id: number | undefined): void {
    if (!id || !confirm('Deseja realmente excluir este produto?')) return;

    this.productService.remover(id).subscribe({
      next: () => this.loadProducts(),
      error: (err) => alert('Erro ao deletar produto')
    });
  }

  // Prepara o formulário para edição
  fillFormForEdit(product: Produto): void {
    this.currentProduct = { ...product };
    this.isEditMode = true;
  }

  // Limpa o formulário e sai do modo de edição
  resetForm(): void {
    this.currentProduct = { id: 0, nome: '', preco: 0, quantidade: 0 };
    this.isEditMode = false;
  }
}