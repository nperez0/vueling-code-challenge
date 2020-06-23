using Domain.Entities;

namespace Domain.Services
{
    public interface ICurrencyConverterService
    {
        double ConvertToEuro(Currency currency, double amount);
    }
}
