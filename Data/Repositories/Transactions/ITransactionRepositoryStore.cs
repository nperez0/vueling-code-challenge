using Data.Dto;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface ITransactionRepositoryStore
    {
        void Save(IEnumerable<TransactionDto> transactions);
    }
}
