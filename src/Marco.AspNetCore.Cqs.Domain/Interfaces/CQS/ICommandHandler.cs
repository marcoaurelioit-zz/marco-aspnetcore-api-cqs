using System.Threading;
using System.Threading.Tasks;

namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Execute(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}