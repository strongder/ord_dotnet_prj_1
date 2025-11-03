using AppProduct.dtos.Category;
using AppProduct.Entity;
using AppProduct.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Service
{
    internal class CategoryService : CommonService<Category, long, CategoryDto, CreateCategoryDto, CreateCategoryDto>
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
