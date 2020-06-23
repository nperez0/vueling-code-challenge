using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class ConversionService : IConversionService
    {
        private IConversionRepository _conversionRepository;
        private IMapper _mapper;

        public ConversionService(IConversionRepository conversionRepository, IMapper mapper)
        {
            _conversionRepository = conversionRepository;
            _mapper = mapper;
        }

        public IEnumerable<ConversionDto> GetAll()
        {
            var conversions = _conversionRepository.FetchAll();

            return _mapper.Map<IEnumerable<Conversion>, IEnumerable<ConversionDto>>(conversions);
        }
    }
}
