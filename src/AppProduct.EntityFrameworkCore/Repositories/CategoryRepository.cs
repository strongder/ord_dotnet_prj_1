using AppProduct.Entity;
using AppProduct.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace AppProduct.Repositories
{
    public class CategoryRepository : BaseRepository<Category, long>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<AppProductDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
