using Domain.Entities;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface ITransactionRepositorySource
    {
        IEnumerable<Transaction> FetchAll();
    }
}
