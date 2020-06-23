using AutoMapper;
using Data.Dto;
using Domain.Entities;
using System.Collections.Generic;

namespace Data.Repositories
{
    public abstract class ConversionRepositorySourceBase
    {
        IMapper _mapper;

        internal ConversionRepositorySourceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IEnumerable<Conversion> Map(IEnumerable<ConversionDto> data)
        {
            var currencies = new List<Currency>();

            return _mapper.Map<IEnumerable<ConversionDto>, IEnumerable<Conversion>>(data, o => o.Items["Currencies"] = currencies);
        }
    }
}
