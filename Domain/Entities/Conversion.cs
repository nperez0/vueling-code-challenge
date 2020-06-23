namespace Domain.Entities
{
    public class Conversion
    {
        public static Conversion Empty => new Conversion() { Rate = 1 };

        private Currency _from;
        private Currency _to;

        public double Rate { get; set; }

        public Currency From
        {
            get { return _from; }
            set
            {
                _from = value;
                _from.AddConversion(this);
            }
        }

        public Currency To
        {
            get { return _to; }
            set
            {
                _to = value;
                _to.AddConversion(this);
            }
        }

        public bool IsViceversa(Conversion conversion)
        {
            return conversion.To == From
                && conversion.From == To;
        }

        public override bool Equals(object obj) =>
            (obj is Conversion) &&
            Equals((Conversion)obj);

        public bool Equals(Conversion conversion) =>
            (!ReferenceEquals(conversion, null)) &&
            (From, To, Rate).Equals((conversion.From, conversion.To, conversion.Rate));

        public override int GetHashCode() => 
            (From, To, Rate).GetHashCode();
    }
}
