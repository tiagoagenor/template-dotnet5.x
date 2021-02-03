using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using servico.notificacao.Application.AutoMapper;

namespace servico.notificacao.Infra.CrossCutting.IoC.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
