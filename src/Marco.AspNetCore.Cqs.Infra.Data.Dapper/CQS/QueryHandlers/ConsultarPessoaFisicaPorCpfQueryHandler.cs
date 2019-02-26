using arco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.Queries;
using Dapper;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.QueryHandlers
{
    public class ConsultarPessoaFisicaPorCpfQueryHandler : IRequestHandler<ConsultarPessoaFisicaPorCpfQuery, PessoaFisica>
    {
        private readonly ContextReadOnly _contextReadOnly;

        public ConsultarPessoaFisicaPorCpfQueryHandler(ContextReadOnly contextReadOnly)
        {
            _contextReadOnly = contextReadOnly ?? throw new ArgumentNullException(nameof(contextReadOnly));
        }

        public async Task<PessoaFisica> Handle(ConsultarPessoaFisicaPorCpfQuery query, CancellationToken cancellationToken)
        {
            if (query.Cpf is null || string.IsNullOrWhiteSpace(query.Cpf?.Numero))
                return null;

            // Caso seja necessário manter uma consulta em cache, utilize o package Marco.Caching
            // https://www.nuget.org/packages/Marco.Caching/

            // Para realizar a consulta utilizando uma base de dados:
            //var parameters = new DynamicParameters();
            //parameters.Add("cpf", query.Cpf, DbType.AnsiString);

            //var sql = "SELECT Cpf, Nome, DataNascimento FROM YourTable WHERE Cpf = @cpf";
            //return (await _contextReadOnly.QueryAsync<PessoaFisica>(sql, parameters)).FirstOrDefault();

            // Fake Pessoa fisica
            return new PessoaFisica
            {
                Cpf = query.Cpf.NumeroComMascara,
                Nome = "Maria da Silva",
                DataNascimento = DateTime.Now.AddYears(-36)
            };
        }
    }
}