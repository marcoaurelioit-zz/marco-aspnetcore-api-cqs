using Marco.AspNetCore.Cqs.Infra.Data.Dapper;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers;
using MediatR;
using System;
using System.Reflection;

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

            services.AddMediatR(typeof(ConsultarPessoaFisicaPorCpfQueryHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}