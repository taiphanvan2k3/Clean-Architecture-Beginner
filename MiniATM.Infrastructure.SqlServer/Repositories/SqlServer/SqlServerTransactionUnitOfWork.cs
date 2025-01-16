using AutoMapper;
using MiniATM.Infrastructure.SqlServer.Repositories.SqlServer.DataContext;
using MiniATM.UseCase.Repositories;
using MiniATM.UseCase.UnitOfWork;

namespace MiniATM.Infrastructure.SqlServer.Repositories.SqlServer
{
    public class SqlServerTransactionUnitOfWork(MiniATMContext context, IMapper mapper) : ITransactionUnitOfWork
    {
        private readonly MiniATMContext context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private ITransactionRepository? _transactionRepository;
        private IBankAccountRepository? _bankAccountRepository;

        // Lazy initialization
        public ITransactionRepository TransactionRepository =>
            _transactionRepository ??= new SqlServerTransactionRepository(context, mapper);
        public IBankAccountRepository BankAccountRepository =>
            _bankAccountRepository ??= new SqlServerBankAccountRepository(context, mapper);

        public Task BeginTransactionAsync()
        {
            // we can use context.Database.BeginTransaction(), but since this is an UoW, we just silently discard changes if SaveChangesAsync is not called

            return Task.CompletedTask;
        }

        public Task CancelAsync()
        {
            // we can use transaction.Commit(), but since this is an UoW, we just silently discard changes if SaveChangesAsync is not called

            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
