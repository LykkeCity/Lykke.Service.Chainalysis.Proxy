using Autofac;
using AzureStorage.Tables;
using Lykke.Common.Log;
using Lykke.Service.ChainalysisMock.Client;
using Lykke.Service.ChainalysisProxy.AzureRepositories;
using Lykke.Service.ChainalysisProxy.Services;
using Lykke.SettingsReader;

namespace Lykke.Service.ChainalysisProxy.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _settings;
        
        public ServiceModule(IReloadingManager<AppSettings> settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChainalysisTransactionStatusRepository>().As<IChainalysisTransactionStatusRepository>().SingleInstance();

            builder.Register(ctx => AzureTableStorage<ProxyUser>.Create(
                _settings.Nested(x => x.ChainalysisProxyService.Db).ConnectionString(x => x.DataConnString),
                "ProxyUser",
                ctx.Resolve<ILogFactory>())).SingleInstance();

            builder.Register(ctx => AzureTableStorage<TransactionStatusEntity>.Create(
                _settings.Nested(x => x.ChainalysisProxyService.Db).ConnectionString(x => x.DataConnString),
                "ChainalyisTxCach", 
                ctx.Resolve<ILogFactory>()));
            
            builder.Register(ctx => new ChainalysisMockClient(_settings.Nested(x => x.ChainalysisProxyService.Chainalysis.ChainalysisUrl).CurrentValue)).As<IChainalysisMockClient>().SingleInstance();
            builder.RegisterType<ChainalysisProxyService>().As<IChainalysisProxyService>().WithParameter("chainalysisKey", _settings.CurrentValue.ChainalysisProxyService.Chainalysis.ChainalysisKey);
        }
    }
}
