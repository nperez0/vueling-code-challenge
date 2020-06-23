using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data.Dto;
using Domain.Entities;
using Domain.Repositories;
using Instrastructure.Files;

namespace Data.Repositories
{
    public class FileTransactionRepository : TransactionRepositorySourceBase, ITransactionRepositorySource, ITransactionRepositoryStore
    {
        private IFileManager _fileManager;

        public FileTransactionRepository(IConversionRepository conversionRepository, IFileManager fileManager, IMapper mapper)
            : base (conversionRepository, mapper)
        {
            _fileManager = fileManager;
        }

        public IEnumerable<Transaction> FetchAll()
        {
            var data = _fileManager.Read<TransactionDto>("transactions.txt");

            return Map(data);
        }

        public void Save(IEnumerable<TransactionDto> transactions)
        {
            _fileManager.Write(transactions, "transactions.txt");
        }
    }
}
