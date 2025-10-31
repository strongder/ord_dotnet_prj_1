using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AppProduct.IService
{
    using Volo.Abp.Application.Dtos;

    public interface ICommonService<TEntity, TKey, TDto, TCreate, TUpdate>
        where TEntity : class
    {
        Task<TDto> GetAsync(TKey id);
        Task<PagedResultDto<TDto>> GetListAsync(GetCommonListInput input);
        Task<TDto> CreateAsync(TCreate input);
        Task<TDto> UpdateAsync(TKey id, TUpdate input);
        Task DeleteAsync(TKey id);
    }

}
