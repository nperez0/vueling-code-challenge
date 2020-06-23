using Domain.Entities;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IConversionRepositorySource
    {
        IEnumerable<Conversion> FetchAll();
    }
}
