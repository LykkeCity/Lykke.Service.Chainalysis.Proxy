using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.ChainalysisMock.Client;
using Lykke.Service.ChainalysisProxy.AzureRepositories;
using Lykke.Service.ChainalysisProxy.Core.Repositories;
using Lykke.Service.ChainalysisProxy.Core.Services;
using Lykke.Service.ChainalysisProxy.Core.Settings.ServiceSettings;
using Lykke.Service.ChainalysisProxy.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.ChainalysisProxy.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<ChainalysisProxySettings> _settings;
        private readonly IReloadingManager<DbSettings> _dbSettings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<ChainalysisProxySettings> settings, ILog log)
        {
            _settings = settings;
            _dbSettings = settings.Nested(x => x.Db);
            _log = log;

            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
           

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            var proxyUserRepository = new ChainalysisProxyUserRepository(
                AzureTableStorage<ProxyUser>.Create(_dbSettings.ConnectionString(x => x.DataConnString),
                    "ProxyUser", _log));
            builder.RegisterInstance<IChainalysisProxyUserRepository>(proxyUserRepository).SingleInstance();

            var riskApiClient = new ChainalysisMockClient(_settings.Nested(x => x.Services.CainalisysUrl).CurrentValue);

            var chaialysisProxyService = new ChainalysisProxyService(proxyUserRepository, riskApiClient, _settings.Nested(x=>x.Services).CurrentValue);
            builder.RegisterInstance<IChainalysisProxyService>(chaialysisProxyService)
                .SingleInstance();

            builder.Populate(_services);
        }

      
    }
}
