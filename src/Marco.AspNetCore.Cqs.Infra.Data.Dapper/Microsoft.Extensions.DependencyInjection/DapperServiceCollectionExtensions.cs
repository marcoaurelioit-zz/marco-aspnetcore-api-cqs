using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;
using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper.Context;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, SqlServerReadOnlySettings sqlServerReadOnlySettings)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (sqlServerReadOnlySettings is null)
                throw new ArgumentNullException(nameof(sqlServerReadOnlySettings));

            services.AddSingleton(sqlServerReadOnlySettings);
            services.AddScoped<ContextReadOnly>();

            // Register query handlers
            services.AddScoped<IQueryHandler<IConsultarPessoaFisicaPorCpfQuery, PessoaFisica>, ConsultarPessoaFisicaPorCpfQueryHandler>();

            return services;
        }
    }
}