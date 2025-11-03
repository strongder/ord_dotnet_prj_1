using AppProduct.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace AppProduct.Repositories
{
    public class BaseRepository<TEntity, TKey> : EfCoreRepository<AppProductDbContext, TEntity, TKey>, IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<AppProductDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
    {
    }
}
