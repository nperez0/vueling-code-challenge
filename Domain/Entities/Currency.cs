using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Currency
    {
        private List<Conversion> _conversions = new List<Conversion>();

        public Currency(string code)
        {
            Code = code;
        }

        public string Code { get; }

        public IReadOnlyCollection<Conversion> Conversions => _conversions;

        public void AddConversion(Conversion conversion)
        {
            if (!_conversions.Contains(conversion))
                _conversions.Add(conversion);
        }

        public bool IsEuro() => Code.Equals("EUR");

        public override bool Equals(object obj) =>
            (obj is Currency) && 
            Equals((Currency) obj);

        public bool Equals(Currency currency) =>
            (!ReferenceEquals(currency, null)) && 
            Code.Equals((currency.Code));

        public override int GetHashCode() => Code.GetHashCode();
    }
}
