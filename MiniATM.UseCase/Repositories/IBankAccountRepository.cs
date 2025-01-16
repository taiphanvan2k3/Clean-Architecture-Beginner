using MiniATM.Entities;

namespace MiniATM.UseCase.Repositories
{
    public interface IBankAccountRepository
    {
        Task<BankAccount?> FindByIdAsync(string accountId);
        Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid customerId);
        Task UpdateAsync(BankAccount fromAccount);
    }
}
