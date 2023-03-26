using Model.Entity;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDomainWritter : IDomainReader
    {
        Task<T> AddAsyncGuid<T>(T entity) where T : class, IEntityGuid;
        Task<int> SaveCoreChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
