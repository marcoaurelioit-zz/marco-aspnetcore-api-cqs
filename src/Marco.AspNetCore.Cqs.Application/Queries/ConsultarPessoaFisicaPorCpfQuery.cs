using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;

namespace Marco.AspNetCore.Cqs.Application.Queries
{
    public class ConsultarPessoaFisicaPorCpfQuery : IConsultarPessoaFisicaPorCpfQuery
    {
        public ConsultarPessoaFisicaPorCpfQuery(string cpf)
        {
            Cpf = cpf;
        }
        public string Cpf { get; set; }
    }
}
