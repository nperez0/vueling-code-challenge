using Application.Dto;
using Application.Services;
using AutoMapper;
using Data.Dto;
using Data.Repositories;
using Domain.Repositories;
using Domain.Services;
using Instrastructure.Files;
using Instrastructure.Logging;
using Instrastructure.Rest;
using Instrastructure.Settings;
using StructureMap;

namespace Api.Infrastructure.StructureMap
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            var settings = new SettingsConfig();

            Scan(_ =>
            {
                _.TheCallingAssembly();
                _.SingleImplementationsOfInterface();
            });

            // Automapper setup
            For<IMapper>().Use(ctx => SetupAutoMapper(ctx)).Singleton();

            // Domain Services
            For<ICurrencyConverterService>().Use<CurrencyConverterService>().Singleton();
            For<ICalculatorTransactionService>().Use<CalculatorTransactionService>().Singleton();

            // Infrastructure
            For<ISettings>().Use(settings).Singleton();
            For<ILogger>().Use<Logger>().Singleton();
            For<IRestClient>().Use<RestClient>().Singleton();
            For<IPathResolver>().Use<PathResolver>().Singleton();
            For<IFileManager>().Use<FileManager>().Singleton();

            // Repositories
            if (!settings.GetBool("DataFromFile"))
            {
                For<IConversionRepositorySource>().Add<ApiConversionRepositorySource>().Singleton();
                For<ITransactionRepositorySource>().Add<ApiTransactionRepositorySource>().Singleton();
            }
            
            For<IConversionRepositorySource>().Add<FileConversionRepository>().Singleton();
            For<IConversionRepositoryStore>().Use<FileConversionRepository>().Singleton();
            For<IConversionRepository>().Use<ConversionRepository>().Singleton();
            
            For<ITransactionRepositorySource>().Add<FileTransactionRepository>().Singleton();
            For<ITransactionRepositoryStore>().Use<FileTransactionRepository>().Singleton();
            For<ITransactionRepository>().Use<TransactionRepository>().Singleton();

            // Application Services
            For<IConversionService>().Use<ConversionService>().Singleton();
            For<ITransactionService>().Use<TransactionService>().Singleton();
        }

        private IMapper SetupAutoMapper(IContext context)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DataMapperProfile>();
                cfg.AddProfile(new ApplicationMapperProfile(context.GetInstance<ICurrencyConverterService>()));
            });

            return config.CreateMapper();
        }
    }
}