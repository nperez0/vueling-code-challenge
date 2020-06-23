using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface ICalculatorTransactionService
    {
        double SumTransactions(IEnumerable<Transaction> transactions);
    }
}
