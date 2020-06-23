using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Services
{
    public class CalculatorTransactionService : ICalculatorTransactionService
    {
        private ICurrencyConverterService _currencyConverterService;

        public CalculatorTransactionService(ICurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
        }

        public double SumTransactions(IEnumerable<Transaction> transactions)
        {
            var total = transactions
                .Sum(GetAmountInEuro);

            // Default round is banker's rounding
            return Math.Round(total, 2);
        }

        private double GetAmountInEuro(Transaction transaction)
        {
            return _currencyConverterService.ConvertToEuro(transaction.Currency, transaction.Amount);
        }
    }
}
