using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ConversionCurrencyResolver : IMemberValueResolver<ConversionDto, Conversion, string, Currency>
    {
        public Currency Resolve(ConversionDto source, Conversion destination, string sourceMember, Currency destMember, ResolutionContext context)
        {
            var currencies = context.Items["Currencies"] as IList<Currency>;
            var currency = currencies.SingleOrDefault(c => c.Code == sourceMember);

            if (currency == null)
            {
                currency = new Currency(sourceMember);
                currencies.Add(currency);
            }

            return currency;
        }
    }
}
