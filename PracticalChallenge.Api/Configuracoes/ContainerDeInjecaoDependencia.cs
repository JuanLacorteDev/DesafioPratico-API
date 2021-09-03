using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PracticalChallenge.Business.Interfaces.Notificacoes;
using PracticalChallenge.Business.Interfaces.Repositorio;
using PracticalChallenge.Business.Interfaces.Servico;
using PracticalChallenge.Business.Notificacoes;
using PracticalChallenge.Business.Servicos;
using PracticalChallenge.Data.Contexto;
using PracticalChallenge.Data.Repositorios;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PracticalChallenge.Api.Configuracoes
{
    public static class ContainerDeInjecaoDependencia
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            #region Contexto

            services.AddScoped<PracticalChallengeContexto>();
            #endregion

            #region Repositórios

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            #endregion

            #region Serviços

            services.AddScoped<IProdutoService, ProdutoService>();
            #endregion

            #region Notificacao

            services.AddScoped<INotificador, Notificador>();
            #endregion

            return services;
        }
    }
}
