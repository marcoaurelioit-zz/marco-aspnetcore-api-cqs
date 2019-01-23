using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}
