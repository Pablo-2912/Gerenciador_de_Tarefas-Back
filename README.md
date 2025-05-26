🧠 Gerenciador de Tarefas – Back-end
Este é o back-end da aplicação Gerenciador de Tarefas, desenvolvido em ASP.NET Core 8 com Entity Framework Core. A API foi criada como parte de um teste técnico para a empresa Data System, e fornece suporte completo às operações de CRUD sobre tarefas.

🚀 Tecnologias Utilizadas
🔧 ASP.NET Core 8

🗃️ Entity Framework Core

🧪 Swagger para documentação e testes

🧱 SQL Server como banco de dados

🧩 Arquitetura em camadas: Application, Domain, Infrastructure

⚙️ Configuração Inicial
Siga os passos abaixo para configurar e rodar o projeto corretamente:

1️⃣ Configurar o CORS
Para que o front-end consiga se comunicar com a API, é necessário liberar o CORS no arquivo Program.cs:

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Porta padrão do Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
E adicione no pipeline:

app.UseCors("AllowReactApp");
2️⃣ Configurar a Conexão com o Banco de Dados (Entity Framework Core)
Abra o arquivo appsettings.json e configure a string de conexão com seu banco SQL Server:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DataSystem;Trusted_Connection=True;TrustServerCertificate=True;"
}
⚠️ Altere o valor conforme seu ambiente local (nome do servidor, autenticação, nome do banco, etc.).

3️⃣ Selecionar a Conexão no Program.cs
No Program.cs, defina que o contexto usará a conexão configurada:

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
4️⃣ Aplicar Migrations Automaticamente
Para garantir que o banco esteja atualizado com as migrations, o seguinte trecho aplica as pendentes na inicialização:

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();
    }
}
5️⃣ Executar a API
Com tudo configurado:

dotnet run
A API estará disponível por padrão em:


https://localhost:5188
A documentação Swagger pode ser acessada em:

https://localhost:5188/swagger
🧩 Estrutura do Projeto
Domain – Modelos de domínio e interfaces de repositórios

Application – Serviços e interfaces de aplicação

Infrastructure – Implementações de repositórios e contexto do banco

API – Camada de apresentação (controllers, Program.cs, etc.)

📌 Melhorias Futuras
Implementar autenticação/autorização (JWT)

Adicionar logs e tratamento global de exceções

Paginação e filtros nas queries

Criar testes automatizados (unitários e de integração)

👨‍💻 Autor
Desenvolvido por [Seu Nome] como parte de um teste técnico para a Data System.
