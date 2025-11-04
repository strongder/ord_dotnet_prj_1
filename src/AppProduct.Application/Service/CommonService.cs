using AppProduct.Dtos;
using AppProduct.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace AppProduct.Service
{
    public class CommonService<TEntity, TKey, TDto, TCreate, TUpdate>
        : ApplicationService, ICommonService<TEntity, TKey, TDto, TCreate, TUpdate>
        where TEntity : class, IEntity<TKey>
    {
        private readonly IRepository<TEntity, TKey> _repository;

        public CommonService(IRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public async Task<TDto> CreateAsync(TCreate input)
        {
            // Map TCreate -> Entity
            var entity = ObjectMapper.Map<TCreate, TEntity>(input);

            // Insert
            entity = await _repository.InsertAsync(entity, autoSave: true);

            // Map Entity -> DTO
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            await _repository.DeleteAsync(id);
        }

        public async Task<TDto> GetAsync(TKey id)
        {
            var entity = await _repository.GetAsync(id);
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        public async Task<PagedResultDto<TDto>> GetListAsync(PageInputDto input)
        {
            CheckGetPagePolicy();
            var queryable = await _repository.GetQueryableAsync();
            queryable = BuildListQuery(queryable, input);

            int totalCount = await AsyncExecuter.CountAsync(queryable);

            queryable = queryable.OrderBy(input.Sorting ?? "Id asc");

            var entities = await AsyncExecuter.ToListAsync(
                queryable.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<TDto>(
                totalCount,
                ObjectMapper.Map<List<TEntity>, List<TDto>>(entities)
            );
        }

        protected virtual IQueryable<TEntity> BuildListQuery(IQueryable<TEntity> queryable, PageInputDto pageInput)
        {
            return queryable;
        }

        public async Task<TDto> UpdateAsync(TKey id, TUpdate input)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            ObjectMapper.Map(input, entity);
            entity = await _repository.UpdateAsync(entity, autoSave: true);
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        public void CheckCreatePolicy()
        {
            // Implement policy check logic here
        }
        public void CheckUpdatePolicy()
        {
            // Implement policy check logic her
        }
        public void CheckDeletePolicy()
        {
            // Implement policy check logic here
        }

        public void CheckGetAllPolicy()
        {
            // Implement policy check logic here
        }

        public void CheckGetPagePolicy()
        {
            // Implement policy check logic here
        }
    }
}