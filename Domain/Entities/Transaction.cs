namespace Domain.Entities
{
    public class Transaction
    {
        public string SKU { get; set; }

        public double Amount { get; set; }

        public Currency Currency { get; set; }
    }
}
