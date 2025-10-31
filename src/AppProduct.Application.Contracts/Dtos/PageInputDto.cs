using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProduct.Dtos
{
    public class PageInputDto
    {
        public int MaxResultCount { get; set; } = 10;
        public int SkipCount { get; set; } = 0;

        public string filter { get; set; } = string.Empty;
        public string sorting { get; set; } = string.Empty;
    }
}
