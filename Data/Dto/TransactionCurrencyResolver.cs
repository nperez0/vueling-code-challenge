using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Data.Dto
{
    public class TransactionCurrencyResolver : IValueResolver<TransactionDto, Transaction, Currency>
    {
        public Currency Resolve(TransactionDto source, Transaction destination, Currency destMember, ResolutionContext context)
        {
            var currencies = context.Items["Currencies"] as IEnumerable<Currency>;

            return currencies.Single(c => c.Code == source.Currency);
        }
    }
}
