using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.Domain.Core.ValueObjects.Documentos;
using MediatR;

namespace Marco.AspNetCore.Cqs.Application.Commands
{
    public class ConsultarPessoaFisicaPorCpfCommand : IRequest<PessoaFisica>
    {      
        public Cpf Cpf { get; private set; }

        public ConsultarPessoaFisicaPorCpfCommand(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
    }
}