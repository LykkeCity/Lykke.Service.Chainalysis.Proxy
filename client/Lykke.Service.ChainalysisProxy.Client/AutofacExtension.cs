using System;
using Autofac;
using AutoMapper;
using Common.Log;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public static class AutofacExtension
    {
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, string serviceUrl, ILog log)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<ChainalysisProxyClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .WithParameter("log", log)
                .As<IChainalysisProxyClient>()
                .SingleInstance();
        }

        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, ChainalysisProxyServiceClientSettings settings, ILog log)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AutorestClient.Models.NewTransactionModel, Contracts.NewTransactionModel>();
                cfg.CreateMap<AutorestClient.Models.NewWalletModel, Contracts.NewWalletModel>();
                cfg.CreateMap<AutorestClient.Models.IUserScoreDetails, Contracts.UserScoreDetails>();
                
            });
            builder.RegisterChainalysisProxyClient(settings?.ServiceUrl, log);
        }
    }
}
