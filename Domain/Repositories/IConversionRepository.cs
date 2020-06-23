using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IConversionRepository
    {
        IEnumerable<Conversion> FetchAll();
    }
}
