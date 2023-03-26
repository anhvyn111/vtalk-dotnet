using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Interface
{
    public interface IDbConnection
    {
        IDbConext Db { get; }
        void SaveChanges();
    }
}
