using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.Domain.Core.ValueObjects.Documentos;
using MediatR;

namespace Marco.AspNetCore.Cqs.Application.Commands
{
    public class ConsultarPessoaFisicaPorCpfCommand : IConsultarPessoaFisicaPorCpfCommand, IRequest<PessoaFisica>
    {
        public ConsultarPessoaFisicaPorCpfCommand(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
        public Cpf Cpf { get; private set; }
    }
}