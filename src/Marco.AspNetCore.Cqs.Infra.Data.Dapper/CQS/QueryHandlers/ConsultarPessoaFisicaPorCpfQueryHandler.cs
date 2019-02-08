using arco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.Queries;
using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper.Context;
using Marco.Caching;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers
{
    public class ConsultarPessoaFisicaPorCpfQueryHandler : IRequestHandler<ConsultarPessoaFisicaPorCpfQuery, PessoaFisica>
    {
        private readonly ICache _cache;
        private readonly ContextReadOnly _contextReadOnly;

        public ConsultarPessoaFisicaPorCpfQueryHandler(ContextReadOnly contextReadOnly, ICache cache)
        {
            _contextReadOnly = contextReadOnly ?? throw new ArgumentNullException(nameof(contextReadOnly));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));           
        }

        public async Task<PessoaFisica> Handle(ConsultarPessoaFisicaPorCpfQuery query, CancellationToken cancellationToken)
        {
            if (query.Cpf is null || string.IsNullOrWhiteSpace(query.Cpf?.Numero))
                return null;

            var cacheKey = $"{nameof(PessoaFisica)}_Cpf:{query.Cpf.Numero}";

            if (!_cache.TryGetValue<PessoaFisica>(cacheKey, out var pessoaFisica))
            {
                // to use database

                //var parameters = new DynamicParameters();
                //parameters.Add("cpf", query.Cpf, DbType.AnsiString);

                //var sql = "SELECT Cpf, Nome, DataNascimento FROM YourTable WHERE Cpf = @cpf";
                //pessoaFisica = (await dbContext.QueryAsync<PessoaFisica>(sql, parameters)).FirstOrDefault();

                // Fake Pessoa fisica
                pessoaFisica = new PessoaFisica
                {
                    Cpf = query.Cpf.NumeroComMascara,
                    Nome = "Maria da Silva",
                    DataNascimento = DateTime.Now.AddYears(-36)
                };

                if (pessoaFisica != null)
                    await _cache.SetAsync(cacheKey, pessoaFisica);
            }

            return pessoaFisica;
        }
    }
}