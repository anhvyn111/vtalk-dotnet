using DBConext.Interface;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class DomainReader : IDomainReader
    {
        public readonly IDbConnection _dbContext;
        public DomainReader(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> User() => QueryByGuid<User>();

        public IQueryable<UserAccount> UserAccount() => QueryByGuid<UserAccount>();

        private IQueryable<T> QueryByGuid<T>(string name = "") where T : class, IEntityGuid
        {
            DbSet<T> dbSet = null;

            if (typeof(ICoreEntity).IsAssignableFrom(typeof(T)))
                dbSet = _dbContext.Db.GetByGuid<T>(!string.IsNullOrEmpty(name) ? name : typeof(T).Name);

            return dbSet;
        }

    }
}
