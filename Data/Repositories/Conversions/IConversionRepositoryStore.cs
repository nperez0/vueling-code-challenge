using Data.Dto;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IConversionRepositoryStore
    {
        void Save(IEnumerable<ConversionDto> conversions);
    }
}
