using Escola.Domain.Entities;
using Escola.Domain.Handlers.EscolaridadeHandlers;
using Escola.Domain.Handlers.UsuarioHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service)
        {
            //Repositories
            service.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository<Usuario>>();
            service.AddScoped<IEscolaridadeRepository<Escolaridade>, EscolaridadeRepository<Escolaridade>>();
            
            //Handlers
            service.AddTransient<UsuarioCreateHandler, UsuarioCreateHandler>();
            service.AddTransient<UsuarioUpdateHandler, UsuarioUpdateHandler>();
            service.AddTransient<UsuarioDeleteHandler, UsuarioDeleteHandler>();
            service.AddTransient<EscolaridadeCreateHandler, EscolaridadeCreateHandler>();
            service.AddTransient<EscolaridadeUpdateHandler, EscolaridadeUpdateHandler>();
            service.AddTransient<EscolaridadeDeleteHandler, EscolaridadeDeleteHandler>();
 
            return service;
        }
    }
}