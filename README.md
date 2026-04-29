# MinimalAPI

Projeto de estudo desenvolvido em **ASP.NET Core Minimal API** para gerenciamento de **administradores** e **veículos**, utilizando autenticação com **JWT** e persistência de dados com **Entity Framework Core + SQL Server**.

## Objetivo

Este projeto foi criado para praticar:

* Estruturação de APIs com Minimal API
* Autenticação e autorização com JWT
* CRUD completo
* Injeção de dependência
* Entity Framework Core
* Organização em camadas

## Tecnologias utilizadas

* .NET / ASP.NET Core
* Minimal API
* Entity Framework Core
* SQL Server
* JWT Bearer Authentication
* Swagger
* Docker

## Funcionalidades

### Administradores

* Login de administrador
* Cadastro de administrador
* Listagem de administradores
* Busca por administrador por ID

### Veículos

* Cadastro de veículo
* Listagem paginada
* Consulta por ID
* Atualização de veículo
* Remoção de veículo

## Estrutura do projeto

```bash
MinimalAPI/
 ├── Controller/
 ├── Db/
 ├── Entidades/
 ├── Enuns/
 ├── Interfaces/
 ├── Models/
 ├── Migrations/
 └── Program.cs
```

## Configuração

No arquivo `appsettings.json`, configure a string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=DbMinimalAPI;Integrated Security=True"
}
```

Configure também a chave JWT:

```json
"Jwt": "sua-chave-secreta"
```

## Como executar

### 1. Restaurar dependências

```bash
dotnet restore
```

### 2. Aplicar migrations

```bash
dotnet ef database update
```

### 3. Executar o projeto

```bash
dotnet run
```

## Swagger

Após iniciar a aplicação, acesse:

```bash
https://localhost:xxxx/swagger
```

## Endpoints principais

### Administradores

| Método | Endpoint                 | Descrição              |
| ------ | ------------------------ | ---------------------- |
| POST   | `/administradores/login` | Login                  |
| POST   | `/administradores`       | Criar administrador    |
| GET    | `/administradores`       | Listar administradores |
| GET    | `/administradores{id}`   | Buscar por ID          |

### Veículos

| Método | Endpoint         | Descrição       |
| ------ | ---------------- | --------------- |
| POST   | `/veiculos`      | Criar veículo   |
| GET    | `/veiculos`      | Listar veículos |
| GET    | `/veiculos/{id}` | Buscar por ID   |
| PUT    | `/veiculos/{id}` | Atualizar       |
| DELETE | `/veiculos/{id}` | Remover         |

## Observações

Alguns endpoints exigem autenticação via token JWT. Após realizar login, envie o token no header:

```bash
Authorization: Bearer seu_token
```

## Autor

Desenvolvido por **Gabriel Henrique Vieira de Oliveira** como projeto de aprendizado em Minimal API com .NET.
