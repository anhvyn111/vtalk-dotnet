using AppConfig.Implementation;
using AppConfig.Interface;
using DBConext.Implementation;
using DBConext.Interface;
using Domain.Implementation;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;

namespace UserService
{
    public static class DIConfig
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection, DbConnection>();
            return services;
        }

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IDomainReader, DomainReader>();
            services.AddScoped<IDomainWritter, DomainWritter>();
            return services;
        }

        public static IServiceCollection AddAppConfig(this IServiceCollection services)
        {
            return services.AddScoped<IConfig, Config>();
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            return services;
        }
    }
}
