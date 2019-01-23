using System.Threading;
using System.Threading.Tasks;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS;
using Marco.AspNetCore.Cqs.Domain.Interfaces.CQS.Queries;
using Marco.AspNetCore.Cqs.Domain.Models;

namespace Marco.AspNetCore.Cqs.Infra.Data.CQS.QueryHandlers
{
    public class ConsultarPessoaFisicaPorCpfQueryHandler : QueryHandler<Context, IQueryHandler<IConsultarPessoaFisicaPorCpfQuery, PessoaFisica>
    {
        public ConsultarPessoaFisicaPorCpfQueryHandler()
            :base()
        {

        }

        public Task<PessoaFisica> Execute(IConsultarPessoaFisicaPorCpfQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}