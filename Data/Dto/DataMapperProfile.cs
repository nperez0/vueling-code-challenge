using AutoMapper;
using Domain.Entities;

namespace Data.Dto
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<ConversionDto, Conversion>()
                .ForMember(x => x.From, y => y.MapFrom<ConversionCurrencyResolver, string>(c => c.From))
                .ForMember(x => x.To, y => y.MapFrom<ConversionCurrencyResolver, string>(c => c.To));

            CreateMap<TransactionDto, Transaction>()
                .ForMember(x => x.Currency, o => o.MapFrom<TransactionCurrencyResolver>());
        }   
    }
}
