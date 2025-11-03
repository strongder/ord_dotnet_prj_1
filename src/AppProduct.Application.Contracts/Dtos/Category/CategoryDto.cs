using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.dtos.Category
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime LastModificationTime { get; set; }
        public DateTime CreationTime { get; set; }
        public long CreatorId { get; set; }
        public long LastModifierId { get; set; }
    }
}
