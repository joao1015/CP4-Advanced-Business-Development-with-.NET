# CP4-Advanced-Business-Development-with-.NET

# 📚 BibliotecaApp

Projeto desenvolvido em **ASP.NET Core Web API** para o **Checkpoint 004 (Advanced Business Development with .NET)** da FIAP.  
A aplicação faz o CRUD da entidade **Livro**, armazenando o **Autor embutido** dentro do documento, conforme o modelo de dados do **MongoDB** (BSON).

---

## 🚀 Funcionalidades
- **POST /api/Livros** → cria um novo livro  
- **GET /api/Livros** → lista todos os livros  
- **GET /api/Livros/{id}** → retorna um livro por id  
- **PUT /api/Livros/{id}** → atualiza um livro existente  
- **DELETE /api/Livros/{id}** → remove um livro  

Exemplo de documento salvo no MongoDB:
```json
{
  "id": "68be180742677b9933888251",
  "titulo": "Dom Casmurro",
  "ano": 1899,
  "autor": {
    "nome": "Machado de Assis",
    "nacionalidade": "Brasileiro"
  }
}



🛠️ Tecnologias

.NET 8 (ASP.NET Core Web API)

MongoDB Atlas (banco de dados online)

MongoDB.Driver

Swagger (Swashbuckle)
Configure sua string de conexão do MongoDB Atlas nos User Secrets do Visual Studio:

{
  "MongoDB": {
    "ConnectionString": "mongodb+srv://<usuario>:<senha>@<cluster>/?retryWrites=true&w=majority"
  }
}


No arquivo appsettings.json, mantenha:

"MongoDB": {
  "DatabaseName": "BibliotecaDb",
  "CollectionName": "Livros"
}


Rode o projeto:

dotnet run


Acesse o Swagger:

https://localhost:<porta>/swagger

👨‍🎓 Autor
Arthur Bispo de Lima -RM 
João Paulo Moreira dos Santos — RM 557808

