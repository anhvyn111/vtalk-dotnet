using DBConext.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Implementation
{
    public static class DbContextFactory
    {
        public static IDbConext CreateDbContext(DbContextName dbContextName, DbContextOptions options) => dbContextName switch
        {
            DbContextName.VtalkUser => new VTalkUserDbContext(options),
            DbContextName.VtalkChannel => new VTalkChannelDbContext(options),
            _ => throw new ArgumentOutOfRangeException(nameof(dbContextName), $"Not expected direction value: {dbContextName}")
        };
    }
}
