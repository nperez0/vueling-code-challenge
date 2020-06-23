using System;
using System.Collections.Generic;
using AutoMapper;
using Data.Dto;
using Domain.Entities;
using Instrastructure.Rest;
using Instrastructure.Settings;

namespace Data.Repositories
{
    public class ApiConversionRepositorySource : ConversionRepositorySourceBase, IConversionRepositorySource
    {
        private IConversionRepositoryStore _store;
        private IRestClient _restClient;
        private ISettings _settings;

        public ApiConversionRepositorySource(IConversionRepositoryStore store, IRestClient restClient, ISettings settings, IMapper mapper)
            : base (mapper)
        {
            _store = store;
            _restClient = restClient;
            _settings = settings;
        }

        public IEnumerable<Conversion> FetchAll()
        {
            var url = new Uri(_settings.GetString("RatesUrl"));

            var data = _restClient.Execute<ConversionDto>(url);
            var conversions = Map(data);

            _store.Save(data);

            return conversions;
        }
    }
}
