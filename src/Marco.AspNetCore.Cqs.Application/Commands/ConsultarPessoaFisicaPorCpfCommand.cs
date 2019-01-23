using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;

namespace Marco.AspNetCore.Cqs.Application.Commands
{
    public class ConsultarPessoaFisicaPorCpfCommand : IConsultarPessoaFisicaPorCpfCommand, IRequest<PessoaFisica>
    {
        public ConsultarPessoaFisicaPorCpfCommand(string cpf)
        {
            Cpf = cpf;
        }
        public string Cpf { get; private set; }
    }
}