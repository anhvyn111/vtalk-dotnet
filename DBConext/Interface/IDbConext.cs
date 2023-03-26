using Microsoft.EntityFrameworkCore;
using Model.Entity;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Interface
{
    public abstract class IDbConext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        public IDbConext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<T> GetByGuid<T>(string name) where T : class, IEntityGuid
        {
            try
            {
                return (DbSet<T>)GetType().GetProperty(name).GetValue(this);
            }
            catch (NullReferenceException)
            {
                throw new Exception($"Dev: Unable to find {name} in {GetType().Name}");
            }

        }
    }
}
