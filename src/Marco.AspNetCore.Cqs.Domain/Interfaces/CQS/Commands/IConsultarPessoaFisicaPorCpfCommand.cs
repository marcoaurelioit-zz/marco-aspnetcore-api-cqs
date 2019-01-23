using Marco.AspNetCore.Cqs.Domain.Models;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands
{
    public interface IConsultarPessoaFisicaPorCpfCommand : ICommand<PessoaFisica>
    {
        string Cpf { get; }
    }
}