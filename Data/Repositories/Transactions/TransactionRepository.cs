using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Instrastructure.Logging;

namespace Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private IEnumerable<ITransactionRepositorySource> _repositorySources;
        private ILogger _logger;

        public TransactionRepository(IEnumerable<ITransactionRepositorySource> repositorySources, ILogger logger)
        {
            _repositorySources = repositorySources;
            _logger = logger;
        }

        public IEnumerable<Transaction> FetchAll()
        {
            return FetchAllInternal();
        }

        public IEnumerable<Transaction> FetchBySku(string sku)
        {
            var transactions = FetchAllInternal();

            return transactions.
                Where(t => t.SKU == sku);
        }

        private IEnumerable<Transaction> FetchAllInternal()
        {
            // todo: create a fluent api to manage multiple sources if fails
            var source = _repositorySources.First();

            try
            {
                return source.FetchAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fecthing from api", ex);

                source = _repositorySources.Skip(1).First();

                if (source != null)
                    return source.FetchAll();

                throw;
            }
        }
    }
}
