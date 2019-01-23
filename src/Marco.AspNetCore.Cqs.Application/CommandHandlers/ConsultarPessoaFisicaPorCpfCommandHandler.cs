using Marco.AspNetCore.Cqs.Application.Commands;
using Marco.AspNetCore.Cqs.Application.Queries;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Commands;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Application.CommandHandlers
{
    public class ConsultarPessoaFisicaPorCpfCommandHandler :
        ICommandHandler<IConsultarPessoaFisicaPorCpfCommand, PessoaFisica>,
        IRequestHandler<ConsultarPessoaFisicaPorCpfCommand, PessoaFisica>
    {
        private readonly IQueryHandler<IConsultarPessoaFisicaPorCpfQuery, PessoaFisica> consultarPessoaFisicaPorCpfQueryHandler;

        public ConsultarPessoaFisicaPorCpfCommandHandler(IQueryHandler<IConsultarPessoaFisicaPorCpfQuery, PessoaFisica> consultarPessoaFisicaPorCpfQueryHandler)
        {
            this.consultarPessoaFisicaPorCpfQueryHandler = consultarPessoaFisicaPorCpfQueryHandler ?? throw new ArgumentNullException(nameof(consultarPessoaFisicaPorCpfQueryHandler));
        }

        public async Task<PessoaFisica> Execute(IConsultarPessoaFisicaPorCpfCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await consultarPessoaFisicaPorCpfQueryHandler.Execute(new ConsultarPessoaFisicaPorCpfQuery(command.Cpf), cancellationToken);
        }

        public async Task<PessoaFisica> Handle(ConsultarPessoaFisicaPorCpfCommand request, CancellationToken cancellationToken) =>
            await Execute(request, cancellationToken);
    }
}