using System.Collections.Generic;
using Application.Dto;

namespace Application.Services
{
    public interface IConversionService
    {
        IEnumerable<ConversionDto> GetAll();
    }
}