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
        public static void RegisterChainalysisProxyClient(this ContainerBuilder builder, string serviceUrl, int timeout)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<ChainalysisProxyClient>()
                .WithParameter("serviceUrl", serviceUrl) 
                .WithParameter("timeout", timeout)
                .As<IChainalysisProxyClient>()
                .SingleInstance();
        }
    }
}
