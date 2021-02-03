using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using servico.notificacao.Domain.Exceptions;
using servico.notificacao.Infra.CrossCutting.Environment.EnvironmentConfiguration;
using System.Linq;
using System.Collections.Generic;
using servico.notificacao.Infra.Proxy.Gmail.src;
using servico.notificacao.Infra.Proxy.Gmail.src.BoasVindas;

namespace servico.notificacao.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            RegisterMediatR(services);
            RegisterEnvironment(services, configuration);
            RegisterGmail(services);
        }

        private static void RegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
        }

        public static void RegisterEnvironment(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("GmailConfiguration").Get<GmailConfiguration>());
        }

        private static void RegisterGmail(IServiceCollection services)
        {
            services.AddScoped<IEnviarEmailGmail, EnviarEmailGmail>();
            services.AddScoped<IBoasVindasGmail, BoasVindasGmail>();
        }
    }
}
