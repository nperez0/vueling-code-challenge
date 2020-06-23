using AutoMapper;
using Data.Dto;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public abstract class TransactionRepositorySourceBase
    {
        IConversionRepository _conversionRepository;
        IMapper _mapper;

        internal TransactionRepositorySourceBase(IConversionRepository conversionRepository, IMapper mapper)
        {
            _conversionRepository = conversionRepository;
            _mapper = mapper;
        }

        protected IEnumerable<Transaction> Map(IEnumerable<TransactionDto> data)
        {
            var conversions = _conversionRepository.FetchAll();
            var currencies = conversions.Select(c => c.From).Distinct();

            return _mapper.Map<IEnumerable<TransactionDto>, IEnumerable<Transaction>>(data, o => o.Items["Currencies"] = currencies);
        }
    }
}
