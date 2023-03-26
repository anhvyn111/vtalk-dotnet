using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfig.Interface
{
    public interface IConfig
    {
        public string GetConnectionString();
        public DbContextName GetDbContextName();
    }
}
