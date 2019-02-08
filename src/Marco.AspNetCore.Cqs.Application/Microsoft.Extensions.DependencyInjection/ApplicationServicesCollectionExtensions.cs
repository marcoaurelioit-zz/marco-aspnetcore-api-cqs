using Marco.AspNetCore.Cqs.Application.CommandHandlers;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServicesCollectionExtensions
    {
        public static IServiceCollection AddCustomApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ConsultarPessoaFisicaPorCpfCommandHandler).GetTypeInfo().Assembly);
            return services;
        }
    }
}