using AppConfig.Interface;
using Microsoft.Extensions.Configuration;
using Model.Enum;
using System;

namespace AppConfig.Implementation
{
    public class Config : IConfig
    {
        private readonly IConfiguration _config;

        public Config(IConfiguration config)
        {
            _config = config;
        }
        public string GetConnectionString() => _config.GetConnectionString("VTalkConnectionStr");

        public DbContextName GetDbContextName() => (DbContextName)Enum.Parse(typeof(DbContextName), _config["DbName"]);
    }
}
