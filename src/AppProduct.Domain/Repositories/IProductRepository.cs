using AppProduct.Entity;
using AppProduct.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Repository
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
    }
}
