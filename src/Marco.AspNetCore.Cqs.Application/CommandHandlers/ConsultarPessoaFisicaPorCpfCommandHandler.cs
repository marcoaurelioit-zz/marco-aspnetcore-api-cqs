using arco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.Queries;
using Marco.AspNetCore.Cqs.Application.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Application.CommandHandlers
{
    public class ConsultarPessoaFisicaPorCpfCommandHandler : IRequestHandler<ConsultarPessoaFisicaPorCpfCommand, PessoaFisica>
    {
        private readonly IMediator _mediator;

        public ConsultarPessoaFisicaPorCpfCommandHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PessoaFisica> Handle(ConsultarPessoaFisicaPorCpfCommand request, CancellationToken cancellationToken)
        {
            // Regras de negócio e demais orquestrações para obter o resultado da consulta.

            return await _mediator.Send(new ConsultarPessoaFisicaPorCpfQuery(request.Cpf.Numero), cancellationToken);
        }
    }
}