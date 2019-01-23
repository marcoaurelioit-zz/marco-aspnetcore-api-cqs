using Marco.AspNetCore.Cqs.Domain.Models;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries
{
    public interface IConsultarPessoaFisicaPorCpfQuery : IQuery<PessoaFisica>
    {
        string Cpf { get; }
    }
}