using CP2.Infrastructure.Repositories; // Namespace que contém a implementação dos repositórios
using CP2.Infrastructure; // Importando o contexto do banco de dados para interações com o DB
using CP2.Domain.Interfaces; // Importando interfaces do domínio
using Microsoft.EntityFrameworkCore; // Importando o Entity Framework Core para manipulação de dados
using CP2.Application.Services; // Importando os serviços de aplicação

var builder = WebApplication.CreateBuilder(args); // Criando o construtor da aplicação

// Configuração da string de conexão para o banco de dados
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configurando o uso do Oracle como provedor de banco de dados

// Registro de serviços no contêiner de injeção de dependência
builder.Services.AddControllers(); // Adiciona suporte a controladores para a API

// Configuração do Swagger para gerar documentação da API
builder.Services.AddEndpointsApiExplorer(); // Habilita a exploração de endpoints
builder.Services.AddSwaggerGen(options =>
{
    // Definindo o caminho do arquivo XML para documentação
    var xmlDocFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
    options.IncludeXmlComments(xmlDocPath); // Inclui comentários XML na documentação
});

// Registro dos repositórios e serviços de aplicação no contêiner
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>(); // Adiciona o repositório de vendedores
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>(); // Adiciona o repositório de fornecedores
builder.Services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>(); // Adiciona o serviço de aplicação para fornecedores

var app = builder.Build(); // Constrói a aplicação

// Configuração do middleware para manipulação de requisições HTTP
if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CP2 API v1"); // Define o endpoint para a documentação
        options.RoutePrefix = string.Empty; // Define a raiz para a UI do Swagger
    });
}

app.UseAuthorization(); // Habilita a autorização
app.MapControllers(); // Mapeia os controladores
app.Run(); // Inicia a aplicação
