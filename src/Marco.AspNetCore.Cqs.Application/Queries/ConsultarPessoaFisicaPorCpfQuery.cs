using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;
using Marco.Domain.Core.ValueObjects.Documentos;

namespace Marco.AspNetCore.Cqs.Application.Queries
{
    public class ConsultarPessoaFisicaPorCpfQuery : IConsultarPessoaFisicaPorCpfQuery
    {
        public Cpf Cpf { get; private set; }

        public ConsultarPessoaFisicaPorCpfQuery(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
    }
}