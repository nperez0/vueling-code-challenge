using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System.Collections.Generic;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        private ICalculatorTransactionService _calculatorTransactionService;
        private IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, ICalculatorTransactionService calculatorTransactionService, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _calculatorTransactionService = calculatorTransactionService;
            _mapper = mapper;
        }

        public IEnumerable<TransactionDto> GetAll()
        {
            var transactions = _transactionRepository.FetchAll();

            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDto>>(transactions);
        }

        public ProductReportDto GetProductReport(string sku)
        {
            var transactions = _transactionRepository.FetchBySku(sku);
            var report = new ProductReportDto();

            report.Transactions = _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionDto>>(transactions);
            report.Total = _calculatorTransactionService.SumTransactions(transactions);

            return report;
        }
    }
}
