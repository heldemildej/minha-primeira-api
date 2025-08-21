# 📌 MinhaPrimeiraAPI

API desenvolvida em **.NET Core 6** para fins de estudo e prática.
O projeto implementa um **CRUD básico** utilizando uma **lista estática em memória** para simular o banco de dados de forma temporária.

---

## 🚀 Tecnologias Utilizadas
- [.NET 6](https://dotnet.microsoft.com/)
- **ASP.NET Core Web API**
- **Swagger** para documentação interativa
- **C#**

---

## 📂 Estrutura do Projeto

```
MinhaPrimeiraAPI/
│── Controllers/
│   └── UsuarioController.cs   # Controlador principal com endpoints CRUD
│── Models/
│   └── UsuarioModel.cs          # Modelo de dados
│── Program.cs                       # Configuração da aplicação
│── appsettings.json                 # Configurações do projeto
```

---

## 📝 Descrição do Projeto

Esta API demonstra como criar endpoints REST em .NET Core 6.
Para simular o banco de dados, utiliza-se uma **lista estática** (`List<UsuarioModel>`) dentro do controller, permitindo operações de:

- **GET** – listar todos os itens ou um item específico.
- **POST** – adicionar um novo item.
- **PUT** – atualizar um item existente.
- **DELETE** – remover um item pelo ID.

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/teu-usuario/minha-primeira-api.git
   ```

2. Acesse a pasta do projeto:
   ```bash
   cd minha-primeira-api
   ```

3. Restaure as dependências:
   ```bash
   dotnet restore
   ```

4. Execute a aplicação:
   ```bash
   dotnet run
   ```

5. Acesse no navegador:
   ```
   https://localhost:5001/swagger
   ```

---

## 📌 Endpoints da API

A API utiliza uma **lista estática** como banco de dados em memória.

### 🔹 GET `/api/Usuario`
Retorna todos os itens.

**Exemplo de Resposta:**
```json
[
  {
    "id": 1,
    "nome": "Item 1"
  },
  {
    "id": 2,
    "nome": "Item 2"
  }
]
```

### 🔹 GET `/api/Usuario/{id}`
Retorna um item específico pelo **ID**.

**Exemplo:**
```
GET /api/minhaprimeira/1
```

**Resposta:**
```json
{
  "id": 1,
  "nome": "Item 1"
}
```

### 🔹 POST `/api/Usuario`
Cria um novo item (adiciona à lista em memória).

**Exemplo de Corpo da Requisição:**
```json
{
  "nome": "Novo Item"
}
```

### 🔹 PUT `/api/Usuario/{id}`
Atualiza um item existente.

**Exemplo de Corpo da Requisição:**
```json
{
  "id": 1,
  "nome": "Item Atualizado"
}
```

### 🔹 DELETE `/api/Usuario/{id}`
Remove um item pelo **ID** da lista.

---

## 🛠 Próximos Passos
- Substituir a lista estática por um banco de dados real (SQL Server, PostgreSQL, etc.).
- Implementar autenticação e autorização.
- Criar testes unitários.
- Configurar CI/CD para publicação.

---

## 👨‍💻 Autor
Desenvolvido por **Heldemilde João**

---

## 📝 Exemplo de Código do Controller com Lista Estática

```csharp
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Lista estática simulando banco de dados
        private static List<MinhaModel> itens = new List<MinhaModel>
        {
            new MinhaModel { Id = 1, Nome = "Item 1" },
            new MinhaModel { Id = 2, Nome = "Item 2" }
        };

        [HttpGet]
        public ActionResult<List<MinhaModel>> Get() => itens;

        [HttpGet("{id}")]
        public ActionResult<MinhaModel> Get(int id)
        {
            var item = itens.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public IActionResult Post(MinhaModel novoItem)
        {
            itens.Add(novoItem);
            return CreatedAtAction(nameof(Get), new { id = novoItem.Id }, novoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MinhaModel itemAtualizado)
        {
            var item = itens.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            item.Nome = itemAtualizado.Nome;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = itens.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            itens.Remove(item);
            return NoContent();
        }
    }
}

