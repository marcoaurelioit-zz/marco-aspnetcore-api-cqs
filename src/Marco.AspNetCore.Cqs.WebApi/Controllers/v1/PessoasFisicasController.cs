using arco.AspNetCore.Cqs.Infra.Data.Dapper.CQS.Queries;
using AutoMapper;
using Marco.AspNetCore.Cqs.Application.Commands;
using Marco.AspNetCore.Cqs.Domain.Models;
using Marco.AspNetCore.Cqs.WebApi.Models.v1;
using Marco.AspNetCore.ExceptionHandling.Serialization;
using Marco.AspNetCore.WebApi.BootStrapper;
using Marco.Exceptions.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class PessoasFisicasController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public PessoasFisicasController(IMediator mediator)=>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        /// <summary>
        /// Exemplo utilizando o command
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("ConsultarViaCommand/{cpf}")]
        [ProducesResponseType(typeof(PessoaFisicaGetResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CoreException), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByCpfCommandAsync([FromRoute]string cpf)
        {
            var command = new ConsultarPessoaFisicaPorCpfCommand(cpf);

            var pessoaFisica = await _mediator.Send(command);

            if (pessoaFisica is null)
                return NotFound();

            return Ok(Mapper.Map<PessoaFisica,PessoaFisicaGetResult>(pessoaFisica));
        }

        /// <summary>
        /// Exemplo utilizando o query
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("ConsultarViaQuery/{cpf}")]
        [ProducesResponseType(typeof(PessoaFisicaGetResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CoreException), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByCpfQueryAsync([FromRoute]string cpf)
        {
            var query = new ConsultarPessoaFisicaPorCpfQuery(cpf);

            var pessoaFisica = await _mediator.Send(query);

            if (pessoaFisica is null)
                return NotFound();

            return Ok(Mapper.Map<PessoaFisica, PessoaFisicaGetResult>(pessoaFisica));
        }
    }
}