using System.Collections.Generic;
using Application.Dto;

namespace Application.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetAll();

        ProductReportDto GetProductReport(string sku);
    }
}