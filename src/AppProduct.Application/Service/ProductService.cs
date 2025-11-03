using AppProduct.dtos.Products;
using AppProduct.Entity;
using AppProduct.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Service
{
    internal class ProductService : CommonService<Product, long, ProductDto, CreateProductDto, CreateProductDto>
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
