using AppProduct.Entity;
using AppProduct.EntityFrameworkCore;
using AppProduct.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AppProduct.Repositories
{
    public class ProductRepository : BaseRepository<Product, long>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<AppProductDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
