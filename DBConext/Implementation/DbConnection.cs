using AppConfig.Interface;
using DBConext.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Implementation
{
    public class DbConnection : IDbConnection
    {
        private readonly Lazy<IDbConext> _currentContext;
        public IDbConext Db => _currentContext.Value;
        public IConfig _config;

        public DbConnection(IConfig appConfig)
        {
            _config = appConfig;
            //var connectionString = config.GetConnectionString(ResolveConnectionStringKey(dbAccessTypeService.AccessType));
            var options = new DbContextOptionsBuilder().UseLazyLoadingProxies().UseSqlServer(_config.GetConnectionString(), o => o.EnableRetryOnFailure()).Options;

            var dbName = _config.GetDbContextName();

            _currentContext = new Lazy<IDbConext>(DbContextFactory.CreateDbContext(dbName, options));
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            SaveChanges();
        }
    }
}
