using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConext.Implementation
{
    public class DbContextBase : DbContext
    {
        protected readonly bool IsWriteAllowed;

        public DbContextBase(DbContextOptions options, bool isWriteAllowed) : base(options)
        {

            IsWriteAllowed = isWriteAllowed;
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (!IsWriteAllowed)
                throw new ApplicationException("Unsupported Operations: SaveChanges. This is a read only connection");

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (!IsWriteAllowed)
                throw new ApplicationException("Unsupported Operations: SaveChanges. This is a read only connection");

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!IsWriteAllowed)
                throw new ApplicationException("Unsupported Operations: SaveChanges. This is a read only connection");

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
