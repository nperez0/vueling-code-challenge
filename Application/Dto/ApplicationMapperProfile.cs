using AutoMapper;
using Domain.Entities;
using Domain.Services;

namespace Application.Dto
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile(ICurrencyConverterService currencyConverter)
        {
            CreateMap<Conversion, ConversionDto>()
                .ForMember(x => x.From, y => y.MapFrom(c => c.From.Code))
                .ForMember(x => x.To, y => y.MapFrom(c => c.To.Code));

            CreateMap<Transaction, TransactionDto>()
                .ForMember(x => x.Amount, y => y.MapFrom(new AmountResolver(currencyConverter)))
                .ForMember(x => x.Currency, y => y.MapFrom(c => "EUR"));
        }   
    }
}
