using System;
using System.Collections.Generic;

namespace Instrastructure.Rest
{
    public interface IRestClient
    {
        IEnumerable<T> Execute<T>(Uri url);
    }
}