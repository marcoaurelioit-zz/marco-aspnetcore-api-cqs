using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;
using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper.Context;
using Marco.Caching;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers
{
    public class ConsultarPessoaFisicaPorCpfQueryHandler : QueryHandler<ContextReadOnly>, IQueryHandler<IConsultarPessoaFisicaPorCpfQuery, PessoaFisica>
    {
        private readonly ICache cache;

        public ConsultarPessoaFisicaPorCpfQueryHandler(ContextReadOnly contextReadOnly, ICache cache)
            : base(contextReadOnly)
        {
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<PessoaFisica> Execute(IConsultarPessoaFisicaPorCpfQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrWhiteSpace(query.Cpf))
                return null;

            var cacheKey = $"{nameof(PessoaFisica)}_Cpf:{query.Cpf}";

            if (!cache.TryGetValue<PessoaFisica>(cacheKey, out var pessoaFisica))
            {
                // to use base date

                //var parameters = new DynamicParameters();
                //parameters.Add("cpf", query.Cpf, DbType.AnsiString);

                //var sql = "SELECT Cpf, Nome, DataNascimento FROM YourTable WHERE Cpf = @cpf";
                //pessoaFisica = (await dbContext.QueryAsync<PessoaFisica>(sql, parameters)).FirstOrDefault();


                // Fake Pessoa fisica
                pessoaFisica = new PessoaFisica
                {
                    Cpf = query.Cpf,
                    Nome = "Maria da Silva",
                    DataNascimento = DateTime.Now.AddYears(-36)
                };

                await cache.SetAsync(cacheKey, pessoaFisica);
            }

            return pessoaFisica;
        }
    }
}