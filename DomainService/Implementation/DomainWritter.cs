using DBConext.Implementation;
using DBConext.Interface;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class DomainWritter : DomainReader, IDomainWritter
    {
        public readonly IDbConnection _dbContext;

        public DomainWritter(IDbConnection dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsyncGuid<T>(T entity) where T : class, IEntityGuid
        {
            if (typeof(ICoreEntity).IsAssignableFrom(typeof(T)))
                await _dbContext.Db.GetByGuid<T>(typeof(T).Name).AddAsync(entity);

            return entity;
        }

        public async Task<int> SaveCoreChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                return await _dbContext.Db.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
