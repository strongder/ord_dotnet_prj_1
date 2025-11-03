using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.dtos.Products
{
    public class CreateProductDto
    {
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public long CategoryId { get; set; }
    }
}
