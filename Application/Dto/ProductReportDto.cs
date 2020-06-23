using System.Collections.Generic;

namespace Application.Dto
{
    public class ProductReportDto
    {
        public IEnumerable<TransactionDto> Transactions { get; set; }

        public double Total { get; set; }
    }
}
