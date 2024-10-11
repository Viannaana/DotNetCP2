using CP2.Infrastructure.Repositories; // Namespace que cont�m a implementa��o dos reposit�rios
using CP2.Infrastructure; // Importando o contexto do banco de dados para intera��es com o DB
using CP2.Domain.Interfaces; // Importando interfaces do dom�nio
using Microsoft.EntityFrameworkCore; // Importando o Entity Framework Core para manipula��o de dados
using CP2.Application.Services; // Importando os servi�os de aplica��o

var builder = WebApplication.CreateBuilder(args); // Criando o construtor da aplica��o

// Configura��o da string de conex�o para o banco de dados
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configurando o uso do Oracle como provedor de banco de dados

// Registro de servi�os no cont�iner de inje��o de depend�ncia
builder.Services.AddControllers(); // Adiciona suporte a controladores para a API

// Configura��o do Swagger para gerar documenta��o da API
builder.Services.AddEndpointsApiExplorer(); // Habilita a explora��o de endpoints
builder.Services.AddSwaggerGen(options =>
{
    // Definindo o caminho do arquivo XML para documenta��o
    var xmlDocFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
    options.IncludeXmlComments(xmlDocPath); // Inclui coment�rios XML na documenta��o
});

// Registro dos reposit�rios e servi�os de aplica��o no cont�iner
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>(); // Adiciona o reposit�rio de vendedores
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>(); // Adiciona o reposit�rio de fornecedores
builder.Services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>(); // Adiciona o servi�o de aplica��o para fornecedores

var app = builder.Build(); // Constr�i a aplica��o

// Configura��o do middleware para manipula��o de requisi��es HTTP
if (app.Environment.IsDevelopment()) // Verifica se o ambiente � de desenvolvimento
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "CP2 API v1"); // Define o endpoint para a documenta��o
        options.RoutePrefix = string.Empty; // Define a raiz para a UI do Swagger
    });
}

app.UseAuthorization(); // Habilita a autoriza��o
app.MapControllers(); // Mapeia os controladores
app.Run(); // Inicia a aplica��o
