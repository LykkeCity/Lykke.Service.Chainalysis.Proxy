using System;
using Autofac;
using Common.Log;
using Lykke.Common.Log;

namespace Lykke.Service.ChainalysisProxy.Client
{
    public static class AutofacExtension
    {
        /// <summary>
        /// Adds Chainalysis Proxy client to the ContainerBuilder instance.
        /// </summary>
        /// <param name="builder">ContainerBuilder instance.</param>
        /// <param name="serviceUrl">Effective Chainalysis Proxy service location.</param>
        /// <param name="log">Logger.</param>
        /// <param name="timeout">Delay for all API methods calls (in seconds).</param>
        [Obsolete("Please, use the overload without explicitly passed logger.")]
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

        /// <summary>
        /// Adds Chainalysis Proxy client to the ContainerBuilder instance.
        /// </summary>
        /// <param name="builder">ContainerBuilder instance. The implementation of ILogFactory should be already injected.</param>
        /// <param name="serviceUrl">Effective Chainalysis Proxy service location.</param>
        /// <param name="timeout">Delay for all API methods calls (in seconds).</param>
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, string serviceUrl, int timeout)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            timeout = Math.Max(0, timeout);

            builder.Register(ctx => new ChainalysisProxyClient(
                serviceUrl,
                ctx.Resolve<ILogFactory>(),
                timeout))
                .As<IChainalysisProxyClient>()
                .SingleInstance();
        }

        /// <summary>
        /// Adds Chainalysis Proxy client to the ContainerBuilder instance.
        /// </summary>
        /// <param name="builder">ContainerBuilder instance.</param>
        /// <param name="settings">Settings.</param>
        /// <param name="log">Logger.</param>
        [Obsolete("Please, use the overload without explicitly passed logger.")]
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, ChainalysisProxyServiceClientSettings settings, ILog log)
        {
            builder.RegisterChainalysisProxyClient(settings?.ServiceUrl, log, settings?.Timeout ?? 0);
        }

        /// <summary>
        /// Adds Chainalysis Proxy client to the ContainerBuilder instance.
        /// </summary>
        /// <param name="builder">ContainerBuilder instance. The implementation of ILogFactory should be already injected.</param>
        /// <param name="settings">Settings.</param>
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, ChainalysisProxyServiceClientSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            builder.RegisterChainalysisProxyClient(settings.ServiceUrl, settings.Timeout);
        }
    }
}
