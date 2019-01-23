using Marco.AspNetCore.Cqs.Application.CommandHandlers;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServicesCollectionExtensions
    {
        public static IServiceCollection AddCustomApplicationServices(this IServiceCollection services)
        {
            // Register commandhandlers
            services.AddScoped<ICommandHandler<IConsultarPessoaFisicaPorCpfCommand, PessoaFisica>, ConsultarPessoaFisicaPorCpfCommandHandler>();

            services.AddMediatR(typeof(ConsultarPessoaFisicaPorCpfCommandHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}