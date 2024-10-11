using CP2.Application.Services;
using CP2.Infrastructure;
using CP2.Infrastructure.Repositories;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CP2.IoC
{
    public static class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            // Configura o contexto do banco de dados com a string de conexão
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseOracle(configuration.GetConnectionString("Oracle")); // Certifique-se de que a chave está correta
            });

            // Registra os repositórios
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();

            // Registra os serviços de aplicação
            services.AddScoped<IFornecedorApplicationService, FornecedorApplicationService>();
            services.AddScoped<IVendedorApplicationService, VendedorApplicationService>();
        }
    }
}
