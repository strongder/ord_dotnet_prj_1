using AppProduct.Dtos;
using AppProduct.IService;
using AppProduct.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization.Permissions;
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
            //await CheckCreatePolicyAsync();
            var entity = ObjectMapper.Map<TCreate, TEntity>(input);
            entity = await _repository.InsertAsync(entity, autoSave: true);
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            await CheckDeletePolicyAsync();
            await _repository.DeleteAsync(id);
        }

        public async Task<TDto> UpdateAsync(TKey id, TUpdate input)
        {
            await CheckUpdatePolicyAsync();
            var entity = await _repository.GetAsync(id);
            ObjectMapper.Map(input, entity);
            entity = await _repository.UpdateAsync(entity, autoSave: true);
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        public virtual async Task<PagedResultDto<TDto>> GetListAsync(PageInputDto input)
        {
            await AuthorizationService.CheckAsync(AppProductPermissions.ProductPermissions.GetPage);

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
        public async Task<TDto> GetAsync(TKey id)
        {
            var entity = await _repository.GetAsync(id);
            return ObjectMapper.Map<TEntity, TDto>(entity);
        }

        protected virtual IQueryable<TEntity> BuildListQuery(IQueryable<TEntity> queryable, PageInputDto pageInput)
        {
            return queryable;
        }


        protected virtual Task CheckCreatePolicyAsync()
        {
            return CheckPolicyAsync(GetCreatePolicyName());
        }

        protected virtual Task CheckUpdatePolicyAsync()
        {
            return CheckPolicyAsync(GetUpdatePolicyName());
        }

        protected virtual Task CheckDeletePolicyAsync()
        {
            return CheckPolicyAsync(GetDeletePolicyName());
        }

        protected virtual Task CheckGetPagePolicyAsync()
        {
            return CheckPolicyAsync(GetGetPagePolicyName());
        }

        protected virtual string GetCreatePolicyName() => null;
        protected virtual string GetUpdatePolicyName() => null;
        protected virtual string GetDeletePolicyName() => null;
        protected virtual string GetGetPagePolicyName() => null;

    }
}