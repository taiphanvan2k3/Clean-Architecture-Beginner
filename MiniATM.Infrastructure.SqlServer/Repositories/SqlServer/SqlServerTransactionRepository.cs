using AutoMapper;
using MiniATM.Infrastructure.SqlServer.Repositories.SqlServer.DataContext;
using MiniATM.UseCase.Repositories;

namespace MiniATM.Infrastructure.SqlServer.Repositories.SqlServer
{
    public class SqlServerTransactionRepository : ITransactionRepository
    {
        private readonly MiniATMContext context;
        private readonly IMapper mapper;

        public SqlServerTransactionRepository(MiniATMContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task Add(Entities.Transaction transaction)
        {
            var dbtransaction = mapper.Map<DataContext.Transaction>(transaction);

            context.Transactions.Add(dbtransaction);
            await context.SaveChangesAsync();
        }
    }
}
