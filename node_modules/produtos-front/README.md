# ProdutosFront

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 22.1.8.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
# 🚀 Projeto API & Frontend

Este é um projeto de treinamento desenvolvido como parte do aprendizado prático no **Bootcamp WomakersCode**. A aplicação simula um cenário real composto por um ecossistema dividido em duas partes: um **Backend (API)** construído em .NET/C# integrado a um banco de dados leve, e uma interface **Frontend** desenvolvida em Angular.

---

## 🛠️ Tecnologias Utilizadas

*   **Backend:** .NET / C#
*   **Banco de Dados:** SQLite (com Entity Framework Core)
*   **Frontend:** Angular
*   **Gerenciador de Pacotes:** NPM / Node.js

---

## 📁 Estrutura do Repositório

```text
ProjetoAPI/
├── api/          # Código fonte do Backend (.NET)
├── frontend/     # Código fonte do Frontend (Angular)
└── README.md     # Documentação do projeto
```

---

## 🚀 Como Executar o Projeto

Para rodar a aplicação completa na sua máquina local, você precisará de **dois terminais abertos simultaneamente**: um para a API e outro para o Frontend.

### 1. Configurando o Banco de Dados e Rodando o Backend (API)

O backend utiliza o **SQLite**. Para criar o arquivo do banco de dados local e aplicar todas as tabelas necessárias na primeira execução, abra o primeiro terminal na raiz do projeto e execute:

```bash
# 1. Navegue até a pasta da API
cd api

# 2. Instale a ferramenta do Entity Framework globalmente (caso não tenha)
dotnet tool install --global dotnet-ef

# 3. Execute as Migrations para criar/atualizar o banco de dados SQLite
dotnet ef database update

# 4. Execute o servidor do backend
dotnet run
```
> 💡 *A API normalmente inicializará no endereço `http://localhost:5000` ou `https://localhost:5001` (confira a saída do seu terminal).*

---

### 2. Configurando e Rodando o Frontend (Angular)

Abra um segundo terminal na raiz do projeto e execute os seguintes comandos:

```bash
# 1. Navegue até a pasta do frontend
cd frontend

# 2. Instale todas as dependências necessárias do projeto
npm install

# 3. Inicie o servidor de desenvolvimento do Angular
ng serve
```
> 🌐 *Após a inicialização do Angular, abra o seu navegador e acesse: **`http://localhost:4200`***

---

## 🛑 Pré-requisitos mínimos

Antes de começar, certifique-se de ter instalado em sua máquina:
*   [SDK do .NET](https://microsoft.com)
*   [Node.js & NPM](https://nodejs.org)
*   [Angular CLI](https://angular.io) (instalado globalmente via `npm install -g @angular/cli`)

---

## 💜 Agradecimentos

Projeto desenvolvido com fins educacionais sob a mentoria e apoio da comunidade **WomakersCode** 🚀
