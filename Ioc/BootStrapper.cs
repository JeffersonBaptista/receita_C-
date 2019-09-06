using Microsoft.Extensions.DependencyInjection;
using receitas.Repositories;
using receitas.Services;

namespace receitas.Ioc
{
    public static class BootStrapper
    {

        
        public static void Register(this IServiceCollection service)
        {
           
           service.AddScoped<IReceitaRepository, ReceitaRepository>();

           service.AddScoped<IReceitaService, ReceitaService>();

        }
        
    }
}