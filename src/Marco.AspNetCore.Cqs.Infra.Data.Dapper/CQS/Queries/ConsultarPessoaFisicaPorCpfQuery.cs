using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.Domain.Core.ValueObjects.Documentos;
using MediatR;

namespace arco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.Queries
{
    public class ConsultarPessoaFisicaPorCpfQuery : IRequest<PessoaFisica>
    {
        public Cpf Cpf { get; private set; }

        public ConsultarPessoaFisicaPorCpfQuery(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
    }
}