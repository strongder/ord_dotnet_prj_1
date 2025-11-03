using AppProduct.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, long>
    {
    }
}
