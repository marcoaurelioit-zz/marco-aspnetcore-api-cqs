﻿using Marco.AspNetCore.ApiConfiguration;
using Marco.AspNetCore.Cqs.Application.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class PessoasFisicasController : ApiBaseController
    {
        private readonly IMediator mediator;

        public PessoasFisicasController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(PessoaFisica), 200)]
        [HttpGet("ConsultarPessoaFisicaPorCpf/{cpf}")]
        public async Task<IActionResult> ConsultarPessoaFisicaPorCpfAsync([FromRoute]string cpf)
        {
            var command = new ConsultarPessoaFisicaPorCpfCommand(cpf);

            var pessoaFisica = await mediator.Send(command);

            if (pessoaFisica is null)
                return NotFound();

            return Ok(pessoaFisica);
        }
    }
}