using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.Domain.Core.ValueObjects.Documentos;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries
{
    public interface IConsultarPessoaFisicaPorCpfQuery : IQuery<PessoaFisica>
    {
        Cpf Cpf { get; }
    }
}