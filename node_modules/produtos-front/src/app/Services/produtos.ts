import { Observable } from 'rxjs';
import { Produto } from '../Models/produto.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class ProdutosService {
private apiUrl = 'http://localhost:5261/api/Produtos';
constructor(private http: HttpClient) {}
listarTodos(): Observable<Produto[]> {
return this.http.get<Produto[]>(this.apiUrl);
}
buscarPorId(id: number): Observable<Produto> {
return this.http.get<Produto>(`${this.apiUrl}/${id}`);
}
criar(produto: { nome: string; preco: number }):
Observable<Produto> {
return this.http.post<Produto>(this.apiUrl, produto);
}
atualizar(id: number, produto: { nome: string; preco: number }):
Observable<Produto> {
return this.http.put<Produto>(`${this.apiUrl}/${id}`, produto);
}
remover(id: number): Observable<void> {
return this.http.delete<void>(`${this.apiUrl}/${id}`);
}
}
