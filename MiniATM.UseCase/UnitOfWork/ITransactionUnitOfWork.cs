using MiniATM.UseCase.Repositories;

namespace MiniATM.UseCase.UnitOfWork
{
    public interface ITransactionUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }
        IBankAccountRepository BankAccountRepository { get; }

        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CancelAsync(); // this method should be called ASAP before leaving, a ITransactionUnitOfWork implementation should implement IDisposable to handle that
    }
}
