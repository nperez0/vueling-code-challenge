using Domain.Entities;
using Domain.Repositories;
using Instrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ConversionRepository : IConversionRepository
    {
        private ILogger _logger;
        private IEnumerable<IConversionRepositorySource> _repositorySources;

        public ConversionRepository(IEnumerable<IConversionRepositorySource> repositorySources, ILogger logger)
        {
            _repositorySources = repositorySources;
            _logger = logger;
        }

        public IEnumerable<Conversion> FetchAll()
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

                source = _repositorySources.Skip(1).FirstOrDefault();

                if (source != null)
                    return source.FetchAll();

                throw;
            }
        }
    }
}
