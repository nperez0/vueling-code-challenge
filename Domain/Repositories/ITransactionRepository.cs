using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> FetchAll();

        IEnumerable<Transaction> FetchBySku(string sku);
    }
}
