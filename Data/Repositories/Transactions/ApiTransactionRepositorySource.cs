using AutoMapper;
using Data.Dto;
using Domain.Entities;
using Domain.Repositories;
using Instrastructure.Rest;
using Instrastructure.Settings;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class ApiTransactionRepositorySource : TransactionRepositorySourceBase, ITransactionRepositorySource
    {
        private ITransactionRepositoryStore _store;
        private IRestClient _restClient;
        private ISettings _settings;

        public ApiTransactionRepositorySource(ITransactionRepositoryStore store, 
            IConversionRepository conversionRepository, 
            IRestClient restClient, 
            ISettings settings, 
            IMapper mapper)
            : base(conversionRepository, mapper)
        {
            _store = store;
            _restClient = restClient;
            _settings = settings;
        }

        public IEnumerable<Transaction> FetchAll()
        {
            var url = new Uri(_settings.GetString("TransactionsUrl"));

            var data = _restClient.Execute<TransactionDto>(url);
            var transactions = Map(data);

            _store.Save(data);

            return transactions;
        }
    }
}
