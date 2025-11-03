using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AppProduct.Dtos
{
    public class PageInputDto : PagedAndSortedResultRequestDto
    {
        public string filter { get; set; } = string.Empty;
    }
}
