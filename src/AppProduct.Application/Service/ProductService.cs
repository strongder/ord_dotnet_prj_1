using AppProduct.dtos.Products;
using AppProduct.Dtos;
using AppProduct.Entity;
using AppProduct.Permissions;
using AppProduct.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Service
{
    [Authorize]
    public class ProductService : CommonService<Product, long, ProductDto, CreateProductDto, CreateProductDto>
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }

        protected override string GetCreatePolicyName()
        {
            return AppProductPermissions.ProductPermissions.Create;
        }

        protected override string GetDeletePolicyName()
        {
            return AppProductPermissions.ProductPermissions.Delete;
        }

        protected override string GetGetPagePolicyName()
        {
            return AppProductPermissions.ProductPermissions.GetPage;
        }

        protected override string GetUpdatePolicyName()
        {
            return AppProductPermissions.ProductPermissions.Edit;
        }
    }
}
