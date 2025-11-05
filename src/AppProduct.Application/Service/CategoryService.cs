using AppProduct.dtos.Category;
using AppProduct.Entity;
using AppProduct.Permissions;
using AppProduct.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Service
{
    public class CategoryService : CommonService<Category, long, CategoryDto, CreateCategoryDto, CreateCategoryDto>
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }

        protected override string GetCreatePolicyName()
        {
            return AppProductPermissions.CategoryPermissions.Create;
        }

        protected override string GetDeletePolicyName()
        {
            return AppProductPermissions.CategoryPermissions.Delete;
        }

        protected override string GetGetPagePolicyName()
        {
            return AppProductPermissions.CategoryPermissions.GetPage;
        }

        protected override string GetUpdatePolicyName()
        {
            return AppProductPermissions.CategoryPermissions.Edit;
        }
    }
}
