namespace Marco.AspNetCore.Cqs.Domain.Interfaces.CQS
{
    public interface ICommand { }

    public interface ICommand<out TResult> : ICommand { }
}