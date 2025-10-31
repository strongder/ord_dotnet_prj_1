using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AppProduct.Entity
{
    public class Category : FullAuditedAggregateRoot<long>
    {

        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
