using System;
using Autofac;
using Common.Log;
using Lykke.Common.Log;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public static class AutofacExtension
    {
        [Obsolete("Please, use the overload which consumes ILogFactory instead.")]
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, string serviceUrl, ILog log, int timeout)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<ChainalysisProxyClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .WithParameter("log", log) 
                .WithParameter("timeout", timeout)
                .As<IChainalysisProxyClient>()
                .SingleInstance();
        }

        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, string serviceUrl, ILogFactory logFactory, int timeout)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (logFactory == null) throw new ArgumentNullException(nameof(logFactory));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<ChainalysisProxyClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .WithParameter("log", logFactory.CreateLog(nameof(ChainalysisProxyClient)))
                .WithParameter("timeout", timeout)
                .As<IChainalysisProxyClient>()
                .SingleInstance();
        }

        [Obsolete("Please, use the overload which consumes ILogFactory instead.")]
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, ChainalysisProxyServiceClientSettings settings, ILog log)
        {
            builder.RegisterChainalysisProxyClient(settings?.ServiceUrl, log, settings?.Timeout ?? 0);
        }

        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, ChainalysisProxyServiceClientSettings settings, ILogFactory logFactory)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (logFactory == null) throw new ArgumentNullException(nameof(logFactory));

            builder.RegisterChainalysisProxyClient(settings.ServiceUrl, logFactory, settings.Timeout);
        }
    }
}
