using AutoMapper;
using Domain.Entities;
using Domain.Services;

namespace Application.Dto
{
    public class AmountResolver : IValueResolver<Transaction, TransactionDto, double>
    {
        ICurrencyConverterService _currencyConverter;

        public AmountResolver(ICurrencyConverterService currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        public double Resolve(Transaction source, TransactionDto destination, double destMember, ResolutionContext context)
        {
            return _currencyConverter.ConvertToEuro(source.Currency, source.Amount);
        }
    }
}
