using AutoMapper;
using Data.Dto;
using Domain.Entities;
using Instrastructure.Files;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class FileConversionRepository : ConversionRepositorySourceBase, IConversionRepositorySource, IConversionRepositoryStore
    {
        private IFileManager _fileManager;

        public FileConversionRepository(IFileManager fileManager, IMapper mapper)
            : base(mapper)
        {
            _fileManager = fileManager;
        }

        public IEnumerable<Conversion> FetchAll()
        {
            var data = _fileManager.Read<ConversionDto>("conversions.txt");

            return Map(data);
        }

        public void Save(IEnumerable<ConversionDto> conversions)
        {
            _fileManager.Write(conversions, "conversions.txt");
        }
    }
}
