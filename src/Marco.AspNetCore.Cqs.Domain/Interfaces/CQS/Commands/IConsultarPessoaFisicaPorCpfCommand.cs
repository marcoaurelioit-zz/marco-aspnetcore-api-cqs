using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.Domain.Core.ValueObjects.Documentos;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands
{
    public interface IConsultarPessoaFisicaPorCpfCommand : ICommand<PessoaFisica>
    {
        Cpf Cpf { get; }
    }
}